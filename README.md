Assignment: Searching for a file

Task

We would like to create an application which can search recursevily for files with a given name under a given folder. Using Visual Studio, create a new console application project. Name the project SeekAndArchive.

Let the application have two command arguments: the first is the file we are looking for, and the second is the directory we must perform the recursive searching. Store this settings in a separated class named: SearchOptions

Provide possibility of saving the search results into xml files. A saved search result should contain the following information:

SearchTerm
Folder: where the files were searched
Date: timestamp when the search was executed
Results: list of search result items:
Filename
Extension
Path: Absolute path to the found file
Create a menu with the following items:

New search: by choosing this the user can execute a new search by giving the search term and folder. As an output, list the absolute path of the files found matching the name. The search is autamatically saved as xml files. Inform the user that the results are saved in file as well.

Browse history: list all previous search results with the following format: [DateTime]: [search_term] in [folder], [amount] items found. For example:

1. 2020-11-09 10:10: 'test' in 'C:\Program Files', 30 items found
2. 2020-11-08 18:15: 'dotnet' in 'C:\temp', 1 items found
3. 2020-11-07 20:20: 'week' in 'C:\Users\Atesz\Documents', 2 items found

Please Enter the number of previous result to print it again!
When the user enter e.g. 2 the system prints out the 'dotnet' search already saved results.

Exit: close the program
