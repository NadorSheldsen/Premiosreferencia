/*
				   File: type_SdtWPWizardPromoData_Modelos
			Description: Modelos
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="WPWizardPromoData.Modelos")]
	[XmlType(TypeName="WPWizardPromoData.Modelos" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPWizardPromoData_Modelos : GxUserType
	{
		public SdtWPWizardPromoData_Modelos( )
		{
			/* Constructor for serialization */
		}

		public SdtWPWizardPromoData_Modelos(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			if (gxTv_SdtWPWizardPromoData_Modelos_Grid != null)
			{
				AddObjectProperty("Grid", gxTv_SdtWPWizardPromoData_Modelos_Grid, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Grid" )]
		[XmlArray(ElementName="Grid"  )]
		[XmlArrayItemAttribute(ElementName="GridItem" , IsNullable=false )]
		public GXBaseCollection<SdtWPWizardPromoData_Modelos_GridItem> gxTpr_Grid
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_Modelos_Grid == null )
				{
					gxTv_SdtWPWizardPromoData_Modelos_Grid = new GXBaseCollection<SdtWPWizardPromoData_Modelos_GridItem>( context, "WPWizardPromoData.Modelos.GridItem", "");
				}
				return gxTv_SdtWPWizardPromoData_Modelos_Grid;
			}
			set {
				gxTv_SdtWPWizardPromoData_Modelos_Grid_N = false;
				gxTv_SdtWPWizardPromoData_Modelos_Grid = value;
				SetDirty("Grid");
			}
		}

		public void gxTv_SdtWPWizardPromoData_Modelos_Grid_SetNull()
		{
			gxTv_SdtWPWizardPromoData_Modelos_Grid_N = true;
			gxTv_SdtWPWizardPromoData_Modelos_Grid = null;
		}

		public bool gxTv_SdtWPWizardPromoData_Modelos_Grid_IsNull()
		{
			return gxTv_SdtWPWizardPromoData_Modelos_Grid == null;
		}
		public bool ShouldSerializegxTpr_Grid_GxSimpleCollection_Json()
		{
			return gxTv_SdtWPWizardPromoData_Modelos_Grid != null && gxTv_SdtWPWizardPromoData_Modelos_Grid.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Grid_GxSimpleCollection_Json() || 
				false);
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWPWizardPromoData_Modelos_Grid_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWPWizardPromoData_Modelos_Grid_N;
		protected GXBaseCollection<SdtWPWizardPromoData_Modelos_GridItem> gxTv_SdtWPWizardPromoData_Modelos_Grid = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPWizardPromoData.Modelos", Namespace="Premios")]
	public class SdtWPWizardPromoData_Modelos_RESTInterface : GxGenericCollectionItem<SdtWPWizardPromoData_Modelos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPWizardPromoData_Modelos_RESTInterface( ) : base()
		{	
		}

		public SdtWPWizardPromoData_Modelos_RESTInterface( SdtWPWizardPromoData_Modelos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Grid", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWPWizardPromoData_Modelos_GridItem_RESTInterface> gxTpr_Grid
		{
			get {
				if (sdt.ShouldSerializegxTpr_Grid_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWPWizardPromoData_Modelos_GridItem_RESTInterface>(sdt.gxTpr_Grid);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Grid);
			}
		}


		#endregion

		public SdtWPWizardPromoData_Modelos sdt
		{
			get { 
				return (SdtWPWizardPromoData_Modelos)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtWPWizardPromoData_Modelos() ;
			}
		}
	}
	#endregion
}