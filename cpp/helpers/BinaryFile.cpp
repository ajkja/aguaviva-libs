#include "stdlib.h"
#include "stdio.h"

bool ReadFile(char *fileName, void **pOut, unsigned int *pSize)
{
	FILE *file;

	fopen_s(&file, fileName, "rb");
	if (!file)
	{
		//fprintf(stderr, "Unable to open file %s", name);
		return false;
	}
	
	//Get file length
	fseek(file, 0, SEEK_END);
	int fileLen=ftell(file);
	fseek(file, 0, SEEK_SET);

	//Allocate memory
	unsigned char *buffer=(unsigned char *)malloc( fileLen );
	if (!buffer)
	{
		//fprintf(stderr, "Memory error!");
      fclose(file);
		return false;
	}

	//Read file contents into buffer
	size_t size = fread(buffer, fileLen, 1, file);

   if ( pSize != NULL)
   {
      *pSize = fileLen;
   }

   *pOut = buffer;

	fclose(file);

	return true;
}


bool WriteFile(char *fileName, unsigned char *pOut, unsigned int fileLen)
{
	FILE *file;
	fopen_s(&file, fileName, "wb");
	if (!file)
	{
		//fprintf(stderr, "Unable to open file %s", name);
		return false;
	}
	
	//Read file contents into buffer
	size_t size = fwrite(pOut, fileLen, 1, file);

	fclose(file);

	return true;
}

