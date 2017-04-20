using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(DataLookUp))]
	public class DataLookUpEditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			DataLookUp s = target as DataLookUp;
			DataLookUpRow r = s.Rows[ Index ];

			EditorGUILayout.BeginHorizontal();
			if ( GUILayout.Button("<<") )
			{
				Index = 0;
			}
			if ( GUILayout.Button("<") )
			{
				Index -= 1;
				if ( Index < 0 )
					Index = s.Rows.Count - 1;
			}
			if ( GUILayout.Button(">") )
			{
				Index += 1;
				if ( Index >= s.Rows.Count )
					Index = 0;
			}
			if ( GUILayout.Button(">>") )
			{
				Index = s.Rows.Count - 1;
			}

			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.LabelField( s.rowNames[ Index ] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_FlavorText", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._FlavorText );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_IconPath", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._IconPath );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_EItemType", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._EItemType );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_EEquipmentType", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._EEquipmentType );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_EItemEquipSlot", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._EItemEquipSlot );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_EItemWeightClass", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._EItemWeightClass );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_EWeaponDamageType", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._EWeaponDamageType );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_EWeaponRange", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._EWeaponRange );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_ItemRarity", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._ItemRarity );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Weight", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Weight );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Health", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Health );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Attack", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Attack );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Strength", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Strength );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Intelect", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Intelect );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Dexterity", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Dexterity );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_EquipLoad", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._EquipLoad );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Durability", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Durability );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_GoldValue", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._GoldValue );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_ScrapValue", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._ScrapValue );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}
