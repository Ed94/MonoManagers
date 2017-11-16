#include "Assets.h"

#include <boost/filesystem.hpp>
#include <iostream			  >

using namespace std;

namespace AbstractRealm
{
	AssetLib::AssetLib()
	{
		printf("Asset Library created. \n");

		assetsLibrary = std::map<std::string, Asset>();

		populate();
	}

	string AssetLib::generateKey(fs::path filePath)
	{
		//C#implementation
		//string key;
		////Fonts
		//if (filePath.Contains("Fonts")) { key = "font_" + name; return key; }
		////Char Text
		//if (filePath.Contains("selection")) { key = "miramo_chars_" + name;  return key; }
		//if (filePath.Contains("miramo_chars"))
		//{
		//	if (filePath.Contains("caps")) { key = "miramo_chars_caps_" + name; return key; }
		//	if (filePath.Contains("digits")) { key = "miramo_chars_digit_" + name; return key; }
		//	if (filePath.Contains("lows")) { key = "miramo_chars_lows_" + name; return key; }
		//	if (filePath.Contains("blank")) { key = "miramo_chars_" + name; return key; }
		//	if (filePath.Contains("delete")) { key = "miramo_chars_" + name; return key; }
		//	if (filePath.Contains("enter")) { key = "miramo_chars_" + name; return key; }
		//	return "";
		//}
		//if (filePath.Contains("miramo_chars/lows")) { key = "miramo_chars_lows" + name;  return key; }
		////Abstract Realm
		//if (filePath.Contains("ar_adventure")) { key = "ar_adventure_" + name; return key; }
		//if (filePath.Contains("ar_conception")) { key = "ar_conception_" + name; return key; }
		//if (filePath.Contains("ar_continue")) { key = "ar_continue_" + name; return key; }
		//if (filePath.Contains("ar_intro")) { key = "ar_intro_" + name; return key; }
		//if (filePath.Contains("ar_leave")) { key = "ar_leave_" + name; return key; }
		//if (filePath.Contains("ar_main")) { key = "ar_main_" + name; return key; }
		//if (filePath.Contains("ar_options")) { key = "ar_options_" + name; return key; }
		//if (filePath.Contains("ar_profile")) { key = "ar_profile_" + name; return key; }
		//if (filePath.Contains("ar_start")) { key = "ar_start_" + name; return key; }
		////UI
		//if (filePath.Contains("UI")) { key = "UI_" + name; return key; }
		////Adventure
		//if (filePath.Contains("slum")) { key = "slum_" + name; return key; }
		//if (filePath.Contains("female"))
		//{
		//	if (filePath.Contains("no_clothes")) { key = "female_no_clothes_" + name; return key; } return "";
		//}
		////Characters
		//if (filePath.Contains("FCB")) { key = name; return key; }
		//if (filePath.Contains("TI_Initial")) { key = "test_" + name; return key; }
		////Testing

		//else    return "";

		//string key;

		//if (filePath.)

		return "";
	}

	void AssetLib::populate()
	{
		printf("Populating asset map. \n");

		int id = 1;

		fs::path directory = "Assets";

		try
		{
			if (exists(directory) && is_directory(directory))
			{
				for (fs::recursive_directory_iterator iterator(directory), atDirectoryEnd; iterator != atDirectoryEnd; iterator++)   //Checks everything inside directory plus subdirectories.
				{
					if (!is_directory(*iterator))   //Makes sure that current iteration is a file.
					{
						fs::path location = iterator->path();   //Gets full file path.

						std::string name = location.stem().string		 ();   //Gets the name of the file.
						std::string key  = generateKey			 (location);   //Generates a key for the map.

						Asset newAsset(name, location);   //Generates a new Asset.

						pair<string, Asset> item(key, newAsset);   //Produces a new item for the asset library map.

						assetsLibrary.insert(item);   //Adds the new item to the map.
					}
				}
			}
		}
		catch (const fs::filesystem_error& thing)
		{
			cout << thing.what() << "\n";
		}
	}
}