//
// Копирайт (С) 2014, ЗАО «Нанософт». Все права защищены.
// 
// Данное программное обеспечение, все исключительные права на него, его
// документация и сопроводительные материалы принадлежат ЗАО «Нанософт».
// Данное программное обеспечение может использоваться при разработке и входить
// в состав разработанных программных продуктов при соблюдении условий
// использования, оговоренных в «Лицензионном договоре присоединения
// на использование программы для ЭВМ nanoCAD».
// 
// Данное программное обеспечение защищено в соответствии с законодательством
// Российской Федерации об интеллектуальной собственности и международными
// правовыми актами.
// 
// Используя данное программное обеспечение,  его документацию и
// сопроводительные материалы вы соглашаетесь с условиями использования,
// указанными выше. 
//

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using Multicad;
using Multicad.AplicationServices;
using Multicad.Runtime;
using Multicad.DatabaseServices;
using Multicad.DataServices;
using Multicad.Geometry;
using Multicad.CustomObjectBase;


namespace CustomObjects
{
	public class Commands
	{
		[CommandMethod("TextInBox", CommandFlags.NoCheck | CommandFlags.NoPrefix)]
		static public void TextInBoxCmd()
		{
			TextInBox obj = new TextInBox();
			obj.DbEntity.Color = Color.Red;
            obj.PlaceObject();
		}
		
		[CommandMethod("TextInBoxEdit", CommandFlags.NoCheck | CommandFlags.NoPrefix)]
		static public void TextInBoxEditCmd()
		{
			McObjectId[] idSelecteds = McObjectManager.SelectObjects("Select TextInBox primitives to edit");
			McObjectId[] idSelectedTextinBox = Array.FindAll(idSelecteds, (s => (s.GetObject()) is TextInBox));

			if (idSelectedTextinBox == null || idSelectedTextinBox.Length == 0)
			{
				MessageBox.Show("No TextInBox primitives selected!");
				return;
			}
            		
			foreach (McObjectId currID in idSelectedTextinBox)
			{
				(currID.GetObject() as TextInBox).Text = "NewText";
			}
		}
	}
}
