/*
				   File: type_SdtWPFacturaWizardData_SelecMedidas_GridItem
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
	[XmlRoot(ElementName="WPFacturaWizardData.SelecMedidas.GridItem")]
	[XmlType(TypeName="WPFacturaWizardData.SelecMedidas.GridItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPFacturaWizardData_SelecMedidas_GridItem : GxUserType
	{
		public SdtWPFacturaWizardData_SelecMedidas_GridItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidanombrecompleto = "";

		}

		public SdtWPFacturaWizardData_SelecMedidas_GridItem(IGxContext context)
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
			AddObjectProperty("MedidaNombreCompleto", gxTpr_Medidanombrecompleto, false);


			AddObjectProperty("Cantidad", gxTpr_Cantidad, false);


			AddObjectProperty("Precio", gxTpr_Precio, false);


			AddObjectProperty("MedidaID", gxTpr_Medidaid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MedidaNombreCompleto")]
		[XmlElement(ElementName="MedidaNombreCompleto")]
		public string gxTpr_Medidanombrecompleto
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidanombrecompleto; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidanombrecompleto = value;
				SetDirty("Medidanombrecompleto");
			}
		}




		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public short gxTpr_Cantidad
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Cantidad; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Cantidad = value;
				SetDirty("Cantidad");
			}
		}



		[SoapElement(ElementName="Precio")]
		[XmlElement(ElementName="Precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Precio = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Precio; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Precio = value;
				SetDirty("Precio");
			}
		}




		[SoapElement(ElementName="MedidaID")]
		[XmlElement(ElementName="MedidaID")]
		public int gxTpr_Medidaid
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidaid; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidaid = value;
				SetDirty("Medidaid");
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
			gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidanombrecompleto = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidanombrecompleto;
		 

		protected short gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Cantidad;
		 

		protected decimal gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Precio;
		 

		protected int gxTv_SdtWPFacturaWizardData_SelecMedidas_GridItem_Medidaid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WPFacturaWizardData.SelecMedidas.GridItem", Namespace="Premios")]
	public class SdtWPFacturaWizardData_SelecMedidas_GridItem_RESTInterface : GxGenericCollectionItem<SdtWPFacturaWizardData_SelecMedidas_GridItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPFacturaWizardData_SelecMedidas_GridItem_RESTInterface( ) : base()
		{	
		}

		public SdtWPFacturaWizardData_SelecMedidas_GridItem_RESTInterface( SdtWPFacturaWizardData_SelecMedidas_GridItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MedidaNombreCompleto", Order=0)]
		public  string gxTpr_Medidanombrecompleto
		{
			get { 
				return sdt.gxTpr_Medidanombrecompleto;

			}
			set { 
				 sdt.gxTpr_Medidanombrecompleto = value;
			}
		}

		[DataMember(Name="Cantidad", Order=1)]
		public short gxTpr_Cantidad
		{
			get { 
				return sdt.gxTpr_Cantidad;

			}
			set { 
				sdt.gxTpr_Cantidad = value;
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

		[DataMember(Name="MedidaID", Order=3)]
		public  string gxTpr_Medidaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Medidaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Medidaid = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtWPFacturaWizardData_SelecMedidas_GridItem sdt
		{
			get { 
				return (SdtWPFacturaWizardData_SelecMedidas_GridItem)Sdt;
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
				sdt = new SdtWPFacturaWizardData_SelecMedidas_GridItem() ;
			}
		}
	}
	#endregion
}