/*
				   File: type_SdtWPWizardPromoData_Modelos_GridItem
			Description: Grid
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
	[XmlRoot(ElementName="WPWizardPromoData.Modelos.GridItem")]
	[XmlType(TypeName="WPWizardPromoData.Modelos.GridItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPWizardPromoData_Modelos_GridItem : GxUserType
	{
		public SdtWPWizardPromoData_Modelos_GridItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modelodescripcion = "";

		}

		public SdtWPWizardPromoData_Modelos_GridItem(IGxContext context)
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
			AddObjectProperty("ModeloDescripcion", gxTpr_Modelodescripcion, false);


			AddObjectProperty("ModeloID", gxTpr_Modeloid, false);


			AddObjectProperty("Precio", gxTpr_Precio, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ModeloDescripcion")]
		[XmlElement(ElementName="ModeloDescripcion")]
		public string gxTpr_Modelodescripcion
		{
			get {
				return gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modelodescripcion; 
			}
			set {
				gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modelodescripcion = value;
				SetDirty("Modelodescripcion");
			}
		}




		[SoapElement(ElementName="ModeloID")]
		[XmlElement(ElementName="ModeloID")]
		public int gxTpr_Modeloid
		{
			get {
				return gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modeloid; 
			}
			set {
				gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modeloid = value;
				SetDirty("Modeloid");
			}
		}



		[SoapElement(ElementName="Precio")]
		[XmlElement(ElementName="Precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPWizardPromoData_Modelos_GridItem_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPWizardPromoData_Modelos_GridItem_Precio = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtWPWizardPromoData_Modelos_GridItem_Precio; 
			}
			set {
				gxTv_SdtWPWizardPromoData_Modelos_GridItem_Precio = value;
				SetDirty("Precio");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
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
			gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modelodescripcion = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modelodescripcion;
		 

		protected int gxTv_SdtWPWizardPromoData_Modelos_GridItem_Modeloid;
		 

		protected decimal gxTv_SdtWPWizardPromoData_Modelos_GridItem_Precio;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WPWizardPromoData.Modelos.GridItem", Namespace="Premios")]
	public class SdtWPWizardPromoData_Modelos_GridItem_RESTInterface : GxGenericCollectionItem<SdtWPWizardPromoData_Modelos_GridItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPWizardPromoData_Modelos_GridItem_RESTInterface( ) : base()
		{	
		}

		public SdtWPWizardPromoData_Modelos_GridItem_RESTInterface( SdtWPWizardPromoData_Modelos_GridItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ModeloDescripcion", Order=0)]
		public  string gxTpr_Modelodescripcion
		{
			get { 
				return sdt.gxTpr_Modelodescripcion;

			}
			set { 
				 sdt.gxTpr_Modelodescripcion = value;
			}
		}

		[DataMember(Name="ModeloID", Order=1)]
		public  string gxTpr_Modeloid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Modeloid, 9, 0));

			}
			set { 
				sdt.gxTpr_Modeloid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Precio", Order=2)]
		public  string gxTpr_Precio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Precio, 10, 2));

			}
			set { 
				sdt.gxTpr_Precio =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtWPWizardPromoData_Modelos_GridItem sdt
		{
			get { 
				return (SdtWPWizardPromoData_Modelos_GridItem)Sdt;
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
				sdt = new SdtWPWizardPromoData_Modelos_GridItem() ;
			}
		}
	}
	#endregion
}