#pragma once
#include <boost/filesystem.hpp>
#include <map				  >
#include <string			  >

namespace fs = boost::filesystem;

namespace AbstractRealm
{
	class Asset
	{
	public:
		Asset												();
		Asset(const std::string name, const fs::path location);

	private:
		std::string	   name    ;
		fs ::path	   location;
		//std::type_info type	   ;
	};

	class AssetLib
	{
	public:
		AssetLib();

		std::string generateKey(fs::path filePath);

		void populate();

	private:
		std::map<std::string, Asset> assetsLibrary;
	};

	class AssetMngr
	{
	public:
		AssetMngr();

	private:
		AssetLib assetLib;
	};
}