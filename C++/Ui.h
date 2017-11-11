#pragma once
//#include "AR.h"
//
//namespace AbstractRealm
//{
//	class UiGrid
//	{
//	public:
//		UiGrid(AssetMngr assetMngr);
//		~UiGrid();
//
//		void createGrid(int sizeX, int sizeY);
//		void setGrid(UiObj uiObj, int posX, int PosY);
//		void updateGridPos(/*direction letsAGO*/);
//		void updateSelected();
//		
//		UiObj getSelObject();
//
//		UiObj getObject(int posX, int posY);
//
//		enum direction;
//
//		std::tuple<int, int> edge;
//		std::tuple<int, int> position;
//
//	private:
//		UiObj naviGrid;
//		UiGrid();
//	};
//
//	class UiMngr
//	{
//	public:
//		 UiMngr();
//		~UiMngr();
//
//		UiObj createUiObj();
//		
//		void checkInput();
//		void drawUi();
//	};
//
//	class UiObj
//	{
//	public:
//		UiObj();
//		~UiObj();
//
//		void runInstruction();
//
//	private:
//		void instruction();
//
//		std::string name;
//		std::tuple<int, int> position;
//	};
//}