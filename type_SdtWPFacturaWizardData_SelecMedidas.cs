/*
				   File: type_SdtWPFacturaWizardData_SelecMedidas
			Description: SelecMedidas
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
	[XmlRoot(ElementName="WPFacturaWizardData.SelecMedidas")]
	[XmlType(TypeName="WPFacturaWizardData.SelecMedidas" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPFacturaWizardData_SelecMedidas : GxUserType
	{
		public SdtWPFacturaWizardData_SelecMedidas( )
		{
			/* Constructor for serialization */
		}

		public SdtWPFacturaWizardData_SelecMedidas(IGxContext context)
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
			if (gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid != null)
			{
				AddObjectProperty("Grid", gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Grid" )]
		[XmlArray(ElementName="Grid"  )]
		[XmlArrayItemAttribute(ElementName="GridItem" , IsNullable=false )]
		public GXBaseCollection<SdtWPFacturaWizardData_SelecMedidas_GridItem> gxTpr_Grid
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid == null )
				{
					gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid = new GXBaseCollection<SdtWPFacturaWizardData_SelecMedidas_GridItem>( context, "WPFacturaWizardData.SelecMedidas.GridItem", "");
				}
				return gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid;
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid_N = false;
				gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid = value;
				SetDirty("Grid");
			}
		}

		public void gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid_SetNull()
		{
			gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid_N = true;
			gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid = null;
		}

		public bool gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid_IsNull()
		{
			return gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid == null;
		}
		public bool ShouldSerializegxTpr_Grid_GxSimpleCollection_Json()
		{
			return gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid != null && gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid.Count > 0;

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
			gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid_N;
		protected GXBaseCollection<SdtWPFacturaWizardData_SelecMedidas_GridItem> gxTv_SdtWPFacturaWizardData_SelecMedidas_Grid = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPFacturaWizardData.SelecMedidas", Namespace="Premios")]
	public class SdtWPFacturaWizardData_SelecMedidas_RESTInterface : GxGenericCollectionItem<SdtWPFacturaWizardData_SelecMedidas>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPFacturaWizardData_SelecMedidas_RESTInterface( ) : base()
		{	
		}

		public SdtWPFacturaWizardData_SelecMedidas_RESTInterface( SdtWPFacturaWizardData_SelecMedidas psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Grid", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWPFacturaWizardData_SelecMedidas_GridItem_RESTInterface> gxTpr_Grid
		{
			get {
				if (sdt.ShouldSerializegxTpr_Grid_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWPFacturaWizardData_SelecMedidas_GridItem_RESTInterface>(sdt.gxTpr_Grid);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Grid);
			}
		}


		#endregion

		public SdtWPFacturaWizardData_SelecMedidas sdt
		{
			get { 
				return (SdtWPFacturaWizardData_SelecMedidas)Sdt;
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
				sdt = new SdtWPFacturaWizardData_SelecMedidas() ;
			}
		}
	}
	#endregion
}