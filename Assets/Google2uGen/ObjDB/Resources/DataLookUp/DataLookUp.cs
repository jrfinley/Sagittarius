//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class DataLookUpRow : IGoogle2uRow
	{
		public string _FlavorText;
		public string _IconPath;
		public string _EItemType;
		public string _EEquipmentType;
		public string _EItemEquipSlot;
		public string _EItemWeightClass;
		public string _EWeaponDamageType;
		public string _EWeaponRange;
		public string _ItemRarity;
		public string _Weight;
		public string _Health;
		public string _Attack;
		public string _Strength;
		public string _Intelect;
		public string _Dexterity;
		public string _EquipLoad;
		public string _Durability;
		public string _GoldValue;
		public string _ScrapValue;
		public DataLookUpRow(string __ItemName, string __FlavorText, string __IconPath, string __EItemType, string __EEquipmentType, string __EItemEquipSlot, string __EItemWeightClass, string __EWeaponDamageType, string __EWeaponRange, string __ItemRarity, string __Weight, string __Health, string __Attack, string __Strength, string __Intelect, string __Dexterity, string __EquipLoad, string __Durability, string __GoldValue, string __ScrapValue) 
		{
			_FlavorText = __FlavorText.Trim();
			_IconPath = __IconPath.Trim();
			_EItemType = __EItemType.Trim();
			_EEquipmentType = __EEquipmentType.Trim();
			_EItemEquipSlot = __EItemEquipSlot.Trim();
			_EItemWeightClass = __EItemWeightClass.Trim();
			_EWeaponDamageType = __EWeaponDamageType.Trim();
			_EWeaponRange = __EWeaponRange.Trim();
			_ItemRarity = __ItemRarity.Trim();
			_Weight = __Weight.Trim();
			_Health = __Health.Trim();
			_Attack = __Attack.Trim();
			_Strength = __Strength.Trim();
			_Intelect = __Intelect.Trim();
			_Dexterity = __Dexterity.Trim();
			_EquipLoad = __EquipLoad.Trim();
			_Durability = __Durability.Trim();
			_GoldValue = __GoldValue.Trim();
			_ScrapValue = __ScrapValue.Trim();
		}

		public int Length { get { return 19; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _FlavorText.ToString();
					break;
				case 1:
					ret = _IconPath.ToString();
					break;
				case 2:
					ret = _EItemType.ToString();
					break;
				case 3:
					ret = _EEquipmentType.ToString();
					break;
				case 4:
					ret = _EItemEquipSlot.ToString();
					break;
				case 5:
					ret = _EItemWeightClass.ToString();
					break;
				case 6:
					ret = _EWeaponDamageType.ToString();
					break;
				case 7:
					ret = _EWeaponRange.ToString();
					break;
				case 8:
					ret = _ItemRarity.ToString();
					break;
				case 9:
					ret = _Weight.ToString();
					break;
				case 10:
					ret = _Health.ToString();
					break;
				case 11:
					ret = _Attack.ToString();
					break;
				case 12:
					ret = _Strength.ToString();
					break;
				case 13:
					ret = _Intelect.ToString();
					break;
				case 14:
					ret = _Dexterity.ToString();
					break;
				case 15:
					ret = _EquipLoad.ToString();
					break;
				case 16:
					ret = _Durability.ToString();
					break;
				case 17:
					ret = _GoldValue.ToString();
					break;
				case 18:
					ret = _ScrapValue.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "_FlavorText":
					ret = _FlavorText.ToString();
					break;
				case "_IconPath":
					ret = _IconPath.ToString();
					break;
				case "_EItemType":
					ret = _EItemType.ToString();
					break;
				case "_EEquipmentType":
					ret = _EEquipmentType.ToString();
					break;
				case "_EItemEquipSlot":
					ret = _EItemEquipSlot.ToString();
					break;
				case "_EItemWeightClass":
					ret = _EItemWeightClass.ToString();
					break;
				case "_EWeaponDamageType":
					ret = _EWeaponDamageType.ToString();
					break;
				case "_EWeaponRange":
					ret = _EWeaponRange.ToString();
					break;
				case "_ItemRarity":
					ret = _ItemRarity.ToString();
					break;
				case "_Weight":
					ret = _Weight.ToString();
					break;
				case "_Health":
					ret = _Health.ToString();
					break;
				case "_Attack":
					ret = _Attack.ToString();
					break;
				case "_Strength":
					ret = _Strength.ToString();
					break;
				case "_Intelect":
					ret = _Intelect.ToString();
					break;
				case "_Dexterity":
					ret = _Dexterity.ToString();
					break;
				case "_EquipLoad":
					ret = _EquipLoad.ToString();
					break;
				case "_Durability":
					ret = _Durability.ToString();
					break;
				case "_GoldValue":
					ret = _GoldValue.ToString();
					break;
				case "_ScrapValue":
					ret = _ScrapValue.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_FlavorText" + " : " + _FlavorText.ToString() + "} ";
			ret += "{" + "_IconPath" + " : " + _IconPath.ToString() + "} ";
			ret += "{" + "_EItemType" + " : " + _EItemType.ToString() + "} ";
			ret += "{" + "_EEquipmentType" + " : " + _EEquipmentType.ToString() + "} ";
			ret += "{" + "_EItemEquipSlot" + " : " + _EItemEquipSlot.ToString() + "} ";
			ret += "{" + "_EItemWeightClass" + " : " + _EItemWeightClass.ToString() + "} ";
			ret += "{" + "_EWeaponDamageType" + " : " + _EWeaponDamageType.ToString() + "} ";
			ret += "{" + "_EWeaponRange" + " : " + _EWeaponRange.ToString() + "} ";
			ret += "{" + "_ItemRarity" + " : " + _ItemRarity.ToString() + "} ";
			ret += "{" + "_Weight" + " : " + _Weight.ToString() + "} ";
			ret += "{" + "_Health" + " : " + _Health.ToString() + "} ";
			ret += "{" + "_Attack" + " : " + _Attack.ToString() + "} ";
			ret += "{" + "_Strength" + " : " + _Strength.ToString() + "} ";
			ret += "{" + "_Intelect" + " : " + _Intelect.ToString() + "} ";
			ret += "{" + "_Dexterity" + " : " + _Dexterity.ToString() + "} ";
			ret += "{" + "_EquipLoad" + " : " + _EquipLoad.ToString() + "} ";
			ret += "{" + "_Durability" + " : " + _Durability.ToString() + "} ";
			ret += "{" + "_GoldValue" + " : " + _GoldValue.ToString() + "} ";
			ret += "{" + "_ScrapValue" + " : " + _ScrapValue.ToString() + "} ";
			return ret;
		}
	}
	public class DataLookUp :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			PotionofHealing, LockPick, Axe, Mace, Dagger, ArmingSword, LongSword, GreatSword, Rapier, ShortBow, LongBow, Crossbow, Armor, Amulet, TestQuestItem
		};
		public string [] rowNames = {
			"string", "Potion of Healing", "Lock Pick", "Axe", "Mace", "Dagger", "Arming Sword", "Long Sword", "Great Sword", "Rapier", "Short Bow", "Long Bow", "Crossbow", "Armor", "Amulet", "TestQuestItem"
		};
		public System.Collections.Generic.List<DataLookUpRow> Rows = new System.Collections.Generic.List<DataLookUpRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new DataLookUpRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7],input[8],input[9],input[10],input[11],input[12],input[13],input[14],input[15],input[16],input[17],input[18],input[19]));
		}
		public override void Clear ()
		{
			Rows.Clear();
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public DataLookUpRow GetRow(rowIds in_RowID)
		{
			DataLookUpRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public DataLookUpRow GetRow(string in_RowString)
		{
			DataLookUpRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
