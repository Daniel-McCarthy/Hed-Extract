# Hed-Extract
Extractor/Packer for PSP Tony Hawk Project 8 .hed/.wad files.


Useage:


	Extraction:
		-Select the .hed or .wad file you wish to use for extraction. If you have both the .hed
		and .wad file in the same folder with the same name it should automatically detect the
		other. If the program fails to find the other, it will have you manually select the file.

		-After selecting the file to extract you must select an EMPTY folder for the files to go.
		If this folder contains files other than what has been extracted, the program will attempt
		to pack them upon rebuilding.


	Rebuilding:

		-Select the exact folder you have selected for extraction. If you select a parent or sub-directory
		from it, it will cause problems with the rebuild.

		-Select the folder you wish for the .hed and .wad file to be saved to. Careful not to choose the
		same folder as the original .hed and .wad file as it may attempt to overwrite them.


Additional information:

	-The current functionality is very simple and basic for the first version. In later versions it will
	no longer be dependent on an empty folder and will support stream/musicp wad files.

	-The .hed file contains header data necessary for extracting the data contained in the .wad file. The
	format specifications are detailed in the about window of the program.


Updates:

	-As of Version 2, users can now extract different types of wads (such as datap and musicp to the same folder)
	and build from this folder. If the user has more than one wad extracted into the base folder, they will be
	prompted to select which they wish to build into a wad/hed file.
	
	-Version 2 now also supports extraction of both Music and Stream variant .hed/.wad files as well as datap .hed/.wads.
	Currently building of this format is still not available until the padding for this variant is understood.
