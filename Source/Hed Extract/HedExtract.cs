using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

/*
Formats:

Hed:
{4 byte offset (integer / files pad data to sections of 2048 bytes, calculated as (offset * 2048))
{4 byte file size (integer)
{X bytes string (because the size is variable, the file pads each header group (offset+filesize+string) until divisible by 4)
{Padding if needed}
...
repeats until hits offset value of FF FF FF FF



Wad
{FileSize bytes data (raw data for the exact fileSize amount, but if the file isn't divisible by 2048, it pads until it is)
{Padding if needed}
...
repeats until end
*/

namespace Hed_Extract
{
    public partial class HedExtract : Form
    {

        public FileStream headerFile;
        public FileStream wadFile;
        public string wadName = "";

        public HedExtract()
        {
            InitializeComponent();
        }

        /*
         *  Method Name: openFolder
         *  Purpose: This method prompts the user to select a folder directory for a variety of purposes required for unpacking/packing
         *  Arguments: char input (Selects folder type to prompt for)
         *  Return: string path (This is either the selected directory, or an empty string if the prompt failed.)
         */
        string openFolder(char input)
        {
            if (input == 'e')
            {
                folderBrowserDialog1.Description = "Select folder to Extract to:";
            }

            if (input == 'b')
            {
                folderBrowserDialog1.Description = "Select folder to Build from (same folder you extracted to):";
            }

            if (input == 'c')
            {
                folderBrowserDialog1.Description = "Please select folder you would like  have .wad and .hed files written to:";
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }

            return "";
        }

        /*
         *  Method Name: openFiles
         *  Purpose: This method prompts the user to select a .hed or .wad file. It then attempts to locate and load the other in the same directory.
         *  Arguments: None
         *  Return: boolean result (True if it was able to locate both. False if any or both failed to open.)
         */
        private bool openFiles()
        {
            //Set up Open File Dialogue to filter for .hed and .wad files
            openFileDialog1.Filter = "HED files (*.)|*.hed|WAD files (*.)|*.wad";
            openFileDialog1.InitialDirectory = Application.StartupPath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = openFileDialog1.FileName;

                //Retrieve file name without Path/Extension
                name = name.Substring(name.LastIndexOf('\\') + 1, name.LastIndexOf('.') - name.LastIndexOf('\\') - 1);
                wadName = name;

                //Retrieve File directory without file name
                string directory = openFileDialog1.FileName;
                directory = directory.Substring(0, directory.LastIndexOf('\\') + 1);

                //Attempt to open both .hed and .wad files

                string wadPath = Path.Combine(directory, name + ".wad");
                if (File.Exists(wadPath))
                {
                    wadFile = File.Open(wadPath, FileMode.Open);
                }
                else
                {
                    MessageBox.Show("Could not find \"" + name + ".wad\"");
                    return false;
                }

                string hedPath = Path.Combine(directory, name + ".hed");
                if (File.Exists(hedPath))
                {
                    headerFile = File.Open(hedPath, FileMode.Open);
                }
                else
                {
                    MessageBox.Show("Could not find \"" + name + ".hed\"");
                    return false;
                }

                if (headerFile != null && wadFile != null)
                {
                    return true;
                }

            }

            return false;
        }

        /*
         *  Method Name: manualOpenFile
         *  Purpose: If there is no .wad file loaded or no .hed file loaded, this method prompts the user to locate one to open.
         *  Arguments: None
         *  Return: boolean result (True if it was able to locate both. False if any or both failed to open.)
         */
        private bool manualOpenFile()
        {
            //If no .wad file has been loaded, prompt the user to locate it.
            if (wadFile == null)
            {
                MessageBox.Show("Please locate your .wad file.");
                openFileDialog1.Filter = "WAD files (*.)|*.wad";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    wadFile = (FileStream)openFileDialog1.OpenFile();
                    string name = openFileDialog1.FileName;
                    wadName = name.Substring(name.LastIndexOf('\\') + 1, name.LastIndexOf('.') - name.LastIndexOf('\\') - 1);
                }
            }

            //If no .hed file has been loaded, prompt the user to locate it.
            if (headerFile == null)
            {
                MessageBox.Show("Please locate your .hed file.");
                openFileDialog1.Filter = "HED files (*.)|*.hed";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    headerFile = (FileStream)openFileDialog1.OpenFile();

                    if (wadName == "")
                    {
                        string name = openFileDialog1.FileName;
                        wadName = name.Substring(name.LastIndexOf('\\') + 1, name.LastIndexOf('.') - name.LastIndexOf('\\') - 1);
                    }
                }
            }

            if (headerFile != null && wadFile != null)
            {
                return true;
            }

            return false;

        }


        /* Method Name: readStringSpiderman
         * Arguments: BinaryReader br (Reader object to wrap header filestream), FileStream headerfile (stream containing data of .hed file to read)
         * Purpose: Read in the text string for the Spiderman format
         */
        private String readStringSpiderman(BinaryReader br, FileStream headerFile)
        {
            String text = "";
            bool foundTerminatorChar = false;
            int i = 0;

            // There must be at least one terminator character, and the string length must be divisible by 4.
            while (!foundTerminatorChar || (foundTerminatorChar && (i % 4) != 0))
            {
                Char currentCharacter = br.ReadChar();
                if (currentCharacter != '\0')
                    text += currentCharacter;
                else
                    foundTerminatorChar = true;
                i++;
            }
            return text;
        }

        /*
         *  Method Name: extractSpidermanWadToFolder
         *  Purpose: Attempt to retrieve and load .hed and .wad file. If successful, attempt to extract to a user selected path.
         */
        private void extractSpidermanWadToFolder(object sender, EventArgs e)
        {
            //Attempt to load .hed and .wad files
            if (openFiles() || manualOpenFile())
            {

                List<string> fileNames = new List<string>();
                List<int> fileSizes = new List<int>();
                List<int> offsets = new List<int>();

                BinaryReader br = new BinaryReader(headerFile, Encoding.ASCII);

                while (headerFile.Position < headerFile.Length)
                {
                    // Read string file name
                    String fileName = readStringSpiderman(br, headerFile);

                    // Read file offset
                    offsets.Add(br.ReadInt32());
                    //Read file size
                    fileSizes.Add(br.ReadInt32());
                    fileNames.Add(fileName);

                    //Skip 1 Byte 0xFF EOF signature
                    if (headerFile.Length - headerFile.Position == 1)
                    {
                        br.ReadBytes(1);
                    }
                }

                // Print out Header data for each file.
                for (int i = 0; i < fileSizes.Count; i++)
                {
                    Console.WriteLine(String.Format("[Header #{0}][{1}][Size:0x{2}][Offset:0x{3}]", i, fileNames[i], fileSizes[i].ToString("X"), offsets[i].ToString("X")));
                }
                Console.WriteLine("____________________________________");

                br.Dispose();
                br.Close();

                progressBar1.Maximum = fileNames.Count;
                progressBar1.Visible = true;


                //Extract Spiderman Wad Format
                extractSpidermanWad(fileNames, fileSizes, offsets);

                wadFile.Close();
                headerFile.Close();
                wadName = "";
            }
            else
            {
                MessageBox.Show("Failed to open .hed and .wad files for extraction.");
            }
        } // Spiderman .hed

        private void extractSpidermanWad(List<string> fileNames, List<int> fileSizes, List<int> offsets)
        {
            BinaryReader br = new BinaryReader(wadFile);

            const int paddingAmount = 0x800;
            const int offsetFileStart = paddingAmount * 5;

            int[] actualOffsets = new int[] { 0x2800, 0x2E000, 0x89000, 0x8A000 };

            //Prompt user for path to save .wad contents to.
            string directory = openFolder('e');

            List<int> previousOffsets = new List<int>();

            //Loop through to extract each file entry found in the .hed file
            for (int i = 0; i < fileNames.Count; i++)
            {
                // Printing out information on the files for debugging purposes
                String fileOffsetHex = String.Format("0x{0}", (offsets[i] + offsetFileStart).ToString("X"));
                String fileEndOffsetHex = String.Format("0x{0}", (offsets[i] + fileSizes[i] + offsetFileStart).ToString("X"));
                String fileSizeHex = String.Format("0x{0}", fileSizes[i].ToString("X"));
                Console.WriteLine(String.Format("[Filename:{0}][Offset:{1}][Size:{2}][File end:{3}]\t[Header Offset:0x{4}]", fileNames[i], fileOffsetHex, fileSizeHex, fileEndOffsetHex, offsets[i].ToString("X")));
                
                // Printing out additional info if the file is one that we know the correct offsets for.
                if (i < actualOffsets.Length) {
                    String actualOffset = actualOffsets[i].ToString("X");
                    String offsetDiff = (actualOffsets[i] - offsets[i]).ToString("X");
                    String fileSizeWithPadding = (fileSizes[i] + (actualOffsets[i] - offsets[i])).ToString("X");
                    int fileStart = offsets[i] + offsetFileStart;
                    int fileEnd = fileStart + fileSizes[i];
                    int fullFileLengthGuess = fileEnd % paddingAmount == 0
                        ? fileEnd
                        : fileEnd + (paddingAmount - (fileEnd % paddingAmount)); // Some files seem to be padded to 0x1000, but some are only 0x800 .. find out if this is consistent or predictable // 0x1000 is divis.. by 0x800..
                    String fileEndGuess = fullFileLengthGuess.ToString("X");
                    Console.WriteLine(String.Format("\t[ActualOffset:0x{0}][Diff:0x{1}][Size with Spacing:0x{2}]\n\t[Guess at file position:0x{3}]", actualOffset, offsetDiff, fileSizeWithPadding, fileEndGuess));
                }
                

                int size = fileSizes[i];
                int offset = offsets[i];

                // Leftover logic from the datap format extraction.
                //Seek to location of next file in .wad (The datap format pads the file data to a length divisible by 2048)
                //wadFile.Position = offsets[i] * 2048;

                wadFile.Position = offset + offsetFileStart;


                //Read file in .wad to byte array
                byte[] file = br.ReadBytes(size);

                //if (file.Length == 0)
                //    Console.WriteLine("Found file with 0 bytes!");

                File.WriteAllBytes(directory + '\\' + fileNames[i], file);
                progressBar1.Value++;
            }

            MessageBox.Show("Extraction complete!");
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }


        /*
         *  Method Name: extractWadToFolder
         *  Purpose: Attempt to retrieve and load .hed and .wad file. If successful, attempt to extract to a user selected path.
         *  Arguments: None
         *  Return: boolean result (True if it was able to locate both. False if any or both failed to open.)
         */
        private void extractWadToFolder()
        {
            //Attempt to load .hed and .wad files
            if (openFiles() || manualOpenFile())
            {

                List<string> fileNames = new List<string>();
                List<int> fileSizes = new List<int>();
                List<int> offsets = new List<int>();

                BinaryReader br = new BinaryReader(headerFile, Encoding.ASCII);

                while (headerFile.Position < headerFile.Length)
                {
                    int curPos = (int)headerFile.Position;

                    //Read file offset
                    offsets.Add(br.ReadInt32());

                    //Read file size
                    fileSizes.Add(br.ReadInt32());

                    //Read in string file name
                    List<char> fileName = new List<char>();
                    while (br.ReadChar() != 0)
                    {
                        headerFile.Seek(-1, SeekOrigin.Current);
                        fileName.Add(br.ReadChar());
                    }

                    char[] name = new char[fileName.Count];
                    fileName.CopyTo(name);
                    fileNames.Add(new string(name));

                    //Skip padding. If the length of the entry is not divisible by 4 it will be padded until it is.
                    int newPos = (int)headerFile.Position;

                    while ((newPos - curPos) % 4 != 0)
                    {
                        br.ReadChar();
                        newPos++;
                    }

                    //Skip 4 Byte 0xFFFFFFFF EOF signature
                    if (headerFile.Length - headerFile.Position == 4)
                    {
                        br.ReadBytes(4);
                    }
                }

                br.Dispose();
                br.Close();

                bool isDataP = identifyWadType(ref fileSizes, ref offsets);

                progressBar1.Maximum = fileNames.Count;
                progressBar1.Visible = true;


                if (isDataP)
                {
                    //Extract DataP Wad Format
                    extractWad(fileNames, fileSizes, offsets);
                }
                else
                {
                    //Extract Music/Stream Wad Format
                    extractMusicStreamWad(fileNames, fileSizes, offsets);
                }

                wadFile.Close();
                headerFile.Close();
                wadName = "";
            }
            else
            {
                MessageBox.Show("Failed to open .hed and .wad files for extraction.");
            }
        } //datap / Music / Stream

        /*
         *  Method Name: extractWad
         *  Purpose: Extracts file data from datap format .wad file to user selected folder.
         *  Arguments: List<string> fileNames (List of each file/directory to extract), List<int> fileSizes (List of byte sizes of each file), List<int> offsets (List of positions of each file in the wad)
         *  Return: None
         */
        void extractWad(List<string> fileNames, List<int> fileSizes, List<int> offsets)
        {

            BinaryReader br = new BinaryReader(wadFile);

            //Prompt user for path to save .wad contents to.
            string directory = openFolder('e');

            //Loop through to extract each file entry found in the .hed file
            for (int i = 0; i < fileNames.Count; i++)
            {

                //Seek to location of next file in .wad (The datap format pads the file data to a length divisible by 2048)
                wadFile.Position = offsets[i] * 2048;

                //Read file in .wad to byte array
                byte[] file = br.ReadBytes(fileSizes[i]);

                //Retrieve file directory from file name
                string secondDirectory = fileNames[i].Substring(0, fileNames[i].LastIndexOf('\\'));

                //Create directory if it does not exist, then write the file data to folder
                if (!Directory.Exists(directory + '\\' + wadName + '\\' + secondDirectory))
                {
                    Directory.CreateDirectory(directory + '\\' + wadName + '\\' + secondDirectory);
                }
                File.WriteAllBytes(directory + '\\' + wadName + '\\' + fileNames[i], file);

                progressBar1.Value++;
            }

            MessageBox.Show("Extraction complete!");
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        /*
         *  Method Name: extractMusicStreamWad
         *  Purpose: Extracts file data from music/stream format .wad file to user selected folder.
         *  Arguments: List<string> fileNames (List of each file/directory to extract), List<int> fileSizes (List of byte sizes of each file), List<int> offsets (List of positions of each file in the wad)
         *  Return: None
         */
        void extractMusicStreamWad(List<string> fileNames, List<int> fileSizes, List<int> offsets)
        {

            BinaryReader br = new BinaryReader(wadFile);

            //Prompt user for path to save .wad contents to.
            string directory = openFolder('e');

            //Loop through to extract each file entry found in the .hed file
            for (int i = 0; i < fileNames.Count; i++)
            {

                //Seek to location of next file in .wad
                wadFile.Position = offsets[i];

                //Read file in .wad to byte array
                byte[] file = br.ReadBytes(fileSizes[i]);

                //Retrieve file directory from file name
                string secondDirectory = fileNames[i].Substring(0, fileNames[i].LastIndexOf('\\'));

                //Create directory if it does not exist, then write the file data to folder
                if (!Directory.Exists(directory + '\\' + wadName + '\\' + secondDirectory))
                {
                    Directory.CreateDirectory(directory + '\\' + wadName + '\\' + secondDirectory);
                }
                File.WriteAllBytes(directory + '\\' + wadName + '\\' + fileNames[i], file);

                progressBar1.Value++;
            }

            MessageBox.Show("Extraction complete!");
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        /*
         *  Method Name: createFromFolder
         *  Purpose: Creates datap format .hed and .wad archive from contents of user selected folder.
         *  Arguments: None
         *  Return: None
         */
        private void createFromFolder()
        {
            //Prompt user for directory to build the archive from.
            string directory = openFolder('b');

            //Prompt user for directory to save the .hed and .wad files to.
            string hedWadDirectory = openFolder('c');


            if (directory != "" && hedWadDirectory != "")
            {
                //Allow user to select a sub-directory of the selected folder if there are any
                string[] subDirectories = Directory.GetDirectories(directory);

                if (subDirectories.Length > 1)
                {
                    DirectorySelector selector = new DirectorySelector();
                    selector.addDirectories(subDirectories);
                    selector.ShowDialog();
                    directory = selector.returnDirectory;
                }
                else
                {
                    directory = subDirectories[0];
                }

                //Use folder name for naming of new .hed and .wad files.
                wadName = directory.Substring(directory.LastIndexOf('\\') + 1, directory.Length - directory.LastIndexOf('\\') - 1);

                //Retrieve file names for all files in selected folder and in the selected folder's subdirectories
                string[] names = Directory.GetFiles(directory + '\\', "*.*", SearchOption.AllDirectories);

                progressBar1.Maximum = names.Length * 2;
                progressBar1.Visible = true;

                if (names.Length > 0)
                {

                    FileStream newHed = new FileStream(hedWadDirectory + '\\' + wadName + ".hed", FileMode.Create);
                    BinaryWriter bwHed = new BinaryWriter(newHed);

                    FileStream newWad = new FileStream(hedWadDirectory + '\\' + wadName + ".wad", FileMode.Create);
                    BinaryWriter bwWad = new BinaryWriter(newWad);

                    int offset = 0;
                    bool final = false;

                    //Loop through and write each file to both .hed and .wad files
                    for (int i = 0; i < names.Length; i++)
                    {
                        using (FileStream file = File.Open(names[i], FileMode.Open))
                        {
                            int fileSize = (int)file.Length;
                            names[i] = names[i].Replace(directory, ""); //remove user's directory from path to get file name

                            if (i + 2 > names.Length) { final = true; }

                            writeFileToHed(ref bwHed, names[i], fileSize, offset, final);
                            writeFileToWad(ref bwWad, file, ref newWad, out offset, final);

                        }
                    }


                    newHed.Close();
                    bwHed.Close();
                    newWad.Close();
                    bwWad.Close();

                    MessageBox.Show("Done building .hed and .wad file!");
                    wadName = "";
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                }
                else
                {
                    MessageBox.Show("Error: No files detected in directory: " + directory);
                }
            }
        }

        /*
         *  Method Name: writeFileToHed
         *  Purpose: Writes file information to a referenced datap .hed file. (This function writes each file segment individually).
         *  Arguments: ref BinaryWriter bw (The binary writer for the .hed file), string name (The name of the file being written), int fileSize (The size of the file being written), int offset (The offset of the file being written), bool final (Indicates whether or not to write the EOF marker.)
         *  Return: None
         */
        void writeFileToHed(ref BinaryWriter bw, string name, int fileSize, int offset, bool final)
        {


            int headerSize = 8 + name.Length + 1;                                               //+ 1 ensures every string has at least one padding byte
            byte[] asciiName = System.Text.Encoding.ASCII.GetBytes(name);                       //forces bw to write exact bytes, no extra byte data

            bw.Write(offset);
            bw.Write(fileSize);
            bw.Write(asciiName);
            bw.Write((byte)0); //one padding byte

            while (headerSize % 4 != 0) //padding if needed
            {
                bw.Write((byte)0);
                headerSize++;
            }

            if (final)
            {
                bw.Write((uint)0xFFFFFFFF); //FF FF FF FF to designate EOF
                
            }
            progressBar1.Value++;
        }

        /*
         *  Method Name: writeFileToWad
         *  Purpose: Writes file data to a referenced datap .wad file. (This function writes each file segment individually).
         *  Arguments: ref BinaryWriter bw (The binary writer for the .wad file), FileStream file (Stream for the file to be written), ref FileStream wadFile (Reference to wad file stream), out int offset (Sends out the offset of the file), bool final (Indicates if the more padding will be required.)
         *  Return: None
         */
        void writeFileToWad(ref BinaryWriter bw, FileStream file, ref FileStream wadFile, out int offset, bool final)
        {

            int size = (int)file.Length;
            int padding = 0;

            file.CopyTo(wadFile);

            //Pads until the file length + padding is divisible by 2048 if more files need to be written
            if (!final)
            {
                if (size % 2048 != 0)
                {
                    while (padding * 2048 < size)
                    {
                        padding++;
                    }

                    int amountOfPadding = (padding * 2048) - size;
                    string paddingString = new string((char)0, amountOfPadding);
                    bw.Write(Encoding.ASCII.GetBytes(paddingString));

                }
            }

            //Sets out reference variable to offset value to be used for the .hed file.
            //The file is padded to be divisible by 2048 bytes so that the offset value
            //can be decreased heavily. The offset is file (length+padding) / 2048.
            offset = (int)wadFile.Length / 2048;

            progressBar1.Value++;

        }

        /*
         *  Method Name: aboutToolStripMenuItem_Click
         *  Purpose: Open About Window
         *  Arguments: None
         *  Return: None
         */
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        /*
         *  Method Name: setMusicStreamModeAndExtractToolStripMenuItem_Click
         *  Purpose: Extract music/stream .wad file archive contents to a user selected folder.
         *  Arguments: None
         *  Return: None
         */
        private void setMusicStreamModeAndExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extractWadToFolder();
        }

        /*
         *  Method Name: setMusicStreamModeAndBuildToolStripMenuItem_Click
         *  Purpose: Create music/stream .wad file archive from contents of a user selected folder.
         *  Arguments: None
         *  Return: None
         */
        private void setMusicStreamModeAndBuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createFromFolder();
        }

        /*
         *  Method Name: setDataModeAndExtractToolStripMenuItem_Click
         *  Purpose: Extract datap .wad file archive contents to a user selected folder.
         *  Arguments: None
         *  Return: None
         */
        private void setDataModeAndExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extractWadToFolder();
        }

        /*
         *  Method Name: setDataModeAndBuildToolStripMenuItem_Click
         *  Purpose: Create datap .wad file archive from contents of a user selected folder.
         *  Arguments: None
         *  Return: None
         */
        private void setDataModeAndBuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createFromFolder();
        }

        /*
         *  Method Name: identifyWadType
         *  Purpose: Determines format of .wad file by comparing the file sizes with the offsets.
         *  Arguments: List<int> fileSizes (List of byte sizes of each file), List<int> offsets (List of positions of each file in the wad)
         *  Return: boolean result (If true, then the format is a datap .wad. If false, it is a music/stream .wad format.)
         */
        private bool identifyWadType(ref List<int> sizes, ref List<int> offsets)
        {
            //Loops through the offsets and sizes to determine format
            for(int i = 0; i + 1 < offsets.Count; i++)
            {
                if(offsets[i + 1] < sizes[i])
                {
                    //The offset is smaller than the previous size
                    //Therefore it is a datap .wad which uses padding
                    //to support large files with smaller size values
                    return true;
                }
            }

            //Each offset is larger than the previous size.
            //Therefore it is not using the datap padding format.
            //It matches the music/stream/thug2 datap format.
            return false;
        }

        private void HedExtract_Load(object sender, EventArgs e)
        {

        }

        /*
        void writeFileToMusicStreamHed(ref BinaryWriter bw, string name, int fileSize, int offset, bool final)
        {


            int headerSize = 8 + name.Length + 1;                                               //+ 1 ensures every string has at least one padding byte
            byte[] asciiName = System.Text.Encoding.ASCII.GetBytes(name);                       //forces bw to write exact bytes, no extra byte data

            bw.Write(offset);//offset
            bw.Write(fileSize); //size
            bw.Write(asciiName); //name
            bw.Write((byte)0); //one padding byte

            while (headerSize % 4 != 0) //padding if needed
            {
                bw.Write((byte)0);
                headerSize++;
            }

            if (final)
            {
                bw.Write((byte)255); //FF FF FF FF to designate EOF
                bw.Write((byte)255);
                bw.Write((byte)255);
                bw.Write((byte)255);
            }
            progressBar1.Value++;
        } //music/stream

        void writeFileToMusicStreamWad(ref BinaryWriter bw, FileStream file, ref FileStream wadFile, out int offset, bool final)
        {


            int size = (int)file.Length;
            int padding = 0;

            file.CopyTo(wadFile);

            if (!final)
            {
                if (size % 2048 != 0)
                {
                    while (padding * 2048 < size)
                    {
                        padding++;
                    }

                    int amountOfPadding = (padding * 2048) - size;
                    string paddingString = new string((char)0, amountOfPadding);
                    bw.Write(Encoding.ASCII.GetBytes(paddingString));

                }
            }

            offset = (int)wadFile.Length / 2048;

            progressBar1.Value++;

        } //music/stream
        */

        /*
        Way to refactor padding:
        int padding = size % 2048;

        if (padding > 0)
             padding = 2048 - padding;

        so to test it out, lets say the size was 2560
        modulo returns 512
        2048 - 512 = 1536
        2560 + 1536 = 4096 which is divisible by 2048
        */

    }
}


