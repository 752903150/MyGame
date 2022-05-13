using System.Collections;
using System.Collections.Generic;

//CreateTime：2022/5/13 15:54:49
namespace DataCs
{
	public struct Data_CultrueAttr_Struct
	{
		public string key;
		public double Prestige;
		public double VillageOutput;
		public double TroopConsumption;
		public double RecruitInfantry;
		public double UpgradeInfantry;
		public double MovementSpeedPenalty;
		public double MilitarySalary;
		public double ArmySalary;
		public double MilitaryUpgrade;
		public double TradePenalty;
		public double MovingSpeed;
		public double UpgradeCavalry;
		public double SpecialOutput;
		public double UrbanTax;
		public double WorkshopIncome;
		public double FieldOfVision;
		public double ConstructionSpeed;

		public Data_CultrueAttr_Struct(string _key, double _Prestige, double _VillageOutput, double _TroopConsumption, double _RecruitInfantry, double _UpgradeInfantry, double _MovementSpeedPenalty, double _MilitarySalary, double _ArmySalary, double _MilitaryUpgrade, double _TradePenalty, double _MovingSpeed, double _UpgradeCavalry, double _SpecialOutput, double _UrbanTax, double _WorkshopIncome, double _FieldOfVision, double _ConstructionSpeed)
		{
			key = _key;
			Prestige = _Prestige;
			VillageOutput = _VillageOutput;
			TroopConsumption = _TroopConsumption;
			RecruitInfantry = _RecruitInfantry;
			UpgradeInfantry = _UpgradeInfantry;
			MovementSpeedPenalty = _MovementSpeedPenalty;
			MilitarySalary = _MilitarySalary;
			ArmySalary = _ArmySalary;
			MilitaryUpgrade = _MilitaryUpgrade;
			TradePenalty = _TradePenalty;
			MovingSpeed = _MovingSpeed;
			UpgradeCavalry = _UpgradeCavalry;
			SpecialOutput = _SpecialOutput;
			UrbanTax = _UrbanTax;
			WorkshopIncome = _WorkshopIncome;
			FieldOfVision = _FieldOfVision;
			ConstructionSpeed = _ConstructionSpeed;
		}
	}

	public static class Data_CultrueAttr
	{
		public static Dictionary<string, Data_CultrueAttr_Struct> Dic = new Dictionary<string, Data_CultrueAttr_Struct>()
		{
			{"Plain",new Data_CultrueAttr_Struct("Plain",1.15d,1.10d,1.10d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d)},
			{"IceSheet",new Data_CultrueAttr_Struct("IceSheet",1d,1d,1d,0.75d,0.75d,1.1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d)},
			{"Plateau",new Data_CultrueAttr_Struct("Plateau",1d,1d,1d,1d,1d,1d,0.85d,0.85d,1.15d,1d,1d,1d,1d,1d,1d,1d,1d)},
			{"Gobi",new Data_CultrueAttr_Struct("Gobi",1d,1d,1d,1d,1d,1d,1.10d,1.10d,1d,0.9d,1.05d,1d,1d,1d,1d,1d,1d)},
			{"Grassland",new Data_CultrueAttr_Struct("Grassland",1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1d,0.85d,1.10d,0.8d,0.9d,1d,1d)},
			{"Forest",new Data_CultrueAttr_Struct("Forest",1d,1d,1d,1d,1d,0.9d,1d,1d,1d,1d,1d,1d,1d,1d,1d,1.1d,0.9d)},
		};
		public static string key_Plain = "Plain";
		public static string key_IceSheet = "IceSheet";
		public static string key_Plateau = "Plateau";
		public static string key_Gobi = "Gobi";
		public static string key_Grassland = "Grassland";
		public static string key_Forest = "Forest";
	}
}

