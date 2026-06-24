/*
				   File: type_SdtWPFacturaWizardData_SelecPromo
			Description: SelecPromo
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
	[XmlRoot(ElementName="WPFacturaWizardData.SelecPromo")]
	[XmlType(TypeName="WPFacturaWizardData.SelecPromo" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPFacturaWizardData_SelecPromo : GxUserType
	{
		public SdtWPFacturaWizardData_SelecPromo( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid_description = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionvigencia = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionbase = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Facturano = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_description = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Facturapdf = "";

		}

		public SdtWPFacturaWizardData_SelecPromo(IGxContext context)
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
			AddObjectProperty("PromocionID_Description", gxTpr_Promocionid_description, false);


			AddObjectProperty("PromocionID", gxTpr_Promocionid, false);


			AddObjectProperty("PromocionVigencia", gxTpr_Promocionvigencia, false);


			AddObjectProperty("PromocionBase", gxTpr_Promocionbase, false);


			AddObjectProperty("FacturaNo", gxTpr_Facturano, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Facturafechafactura)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Facturafechafactura)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Facturafechafactura)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FacturaFechaFactura", sDateCnv, false);



			AddObjectProperty("ModeloID_Description", gxTpr_Modeloid_description, false);

			if (gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid != null)
			{
				AddObjectProperty("ModeloID", gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid, false);
			}

			AddObjectProperty("FacturaPDF", gxTpr_Facturapdf, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PromocionID_Description")]
		[XmlElement(ElementName="PromocionID_Description")]
		public string gxTpr_Promocionid_description
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid_description; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid_description = value;
				SetDirty("Promocionid_description");
			}
		}




		[SoapElement(ElementName="PromocionID")]
		[XmlElement(ElementName="PromocionID")]
		public int gxTpr_Promocionid
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid = value;
				SetDirty("Promocionid");
			}
		}




		[SoapElement(ElementName="PromocionVigencia")]
		[XmlElement(ElementName="PromocionVigencia")]
		public string gxTpr_Promocionvigencia
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionvigencia; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionvigencia = value;
				SetDirty("Promocionvigencia");
			}
		}




		[SoapElement(ElementName="PromocionBase")]
		[XmlElement(ElementName="PromocionBase")]
		public string gxTpr_Promocionbase
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionbase; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionbase = value;
				SetDirty("Promocionbase");
			}
		}




		[SoapElement(ElementName="FacturaNo")]
		[XmlElement(ElementName="FacturaNo")]
		public string gxTpr_Facturano
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Facturano; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Facturano = value;
				SetDirty("Facturano");
			}
		}



		[SoapElement(ElementName="FacturaFechaFactura")]
		[XmlElement(ElementName="FacturaFechaFactura" , IsNullable=true)]
		public string gxTpr_Facturafechafactura_Nullable
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_SelecPromo_Facturafechafactura == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPFacturaWizardData_SelecPromo_Facturafechafactura).value ;
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Facturafechafactura = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Facturafechafactura
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Facturafechafactura; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Facturafechafactura = value;
				SetDirty("Facturafechafactura");
			}
		}



		[SoapElement(ElementName="ModeloID_Description")]
		[XmlElement(ElementName="ModeloID_Description")]
		public string gxTpr_Modeloid_description
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_description; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_description = value;
				SetDirty("Modeloid_description");
			}
		}




		[SoapElement(ElementName="ModeloID" )]
		[XmlArray(ElementName="ModeloID"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<int> gxTpr_Modeloid_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid == null )
				{
					gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid = new GxSimpleCollection<int>( );
				}
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid;
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_N = false;
				gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<int> gxTpr_Modeloid
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid == null )
				{
					gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid = new GxSimpleCollection<int>();
				}
				gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_N = false;
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid ;
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_N = false;
				gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid = value;
				SetDirty("Modeloid");
			}
		}

		public void gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_SetNull()
		{
			gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_N = true;
			gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid = null;
		}

		public bool gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_IsNull()
		{
			return gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid == null;
		}
		public bool ShouldSerializegxTpr_Modeloid_GxSimpleCollection_Json()
		{
			return gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid != null && gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid.Count > 0;

		}

		[SoapElement(ElementName="FacturaPDF")]
		[XmlElement(ElementName="FacturaPDF")]
		[GxUpload()]
		public byte[] gxTpr_Facturapdf_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtWPFacturaWizardData_SelecPromo_Facturapdf) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtWPFacturaWizardData_SelecPromo_Facturapdf=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Facturapdf
		{
			get {
				return gxTv_SdtWPFacturaWizardData_SelecPromo_Facturapdf; 
			}
			set {
				gxTv_SdtWPFacturaWizardData_SelecPromo_Facturapdf = value;
				SetDirty("Facturapdf");
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
			gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid_description = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionvigencia = "";
			gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionbase = "";
			gxTv_SdtWPFacturaWizardData_SelecPromo_Facturano = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_description = "";

			gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_N = true;

			gxTv_SdtWPFacturaWizardData_SelecPromo_Facturapdf = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid_description;
		 

		protected int gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionid;
		 

		protected string gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionvigencia;
		 

		protected string gxTv_SdtWPFacturaWizardData_SelecPromo_Promocionbase;
		 

		protected string gxTv_SdtWPFacturaWizardData_SelecPromo_Facturano;
		 

		protected DateTime gxTv_SdtWPFacturaWizardData_SelecPromo_Facturafechafactura;
		 

		protected string gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_description;
		 
		protected bool gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid_N;
		protected GxSimpleCollection<int> gxTv_SdtWPFacturaWizardData_SelecPromo_Modeloid = null;  

		protected string gxTv_SdtWPFacturaWizardData_SelecPromo_Facturapdf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPFacturaWizardData.SelecPromo", Namespace="Premios")]
	public class SdtWPFacturaWizardData_SelecPromo_RESTInterface : GxGenericCollectionItem<SdtWPFacturaWizardData_SelecPromo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPFacturaWizardData_SelecPromo_RESTInterface( ) : base()
		{	
		}

		public SdtWPFacturaWizardData_SelecPromo_RESTInterface( SdtWPFacturaWizardData_SelecPromo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PromocionID_Description", Order=0)]
		public  string gxTpr_Promocionid_description
		{
			get { 
				return sdt.gxTpr_Promocionid_description;

			}
			set { 
				 sdt.gxTpr_Promocionid_description = value;
			}
		}

		[DataMember(Name="PromocionID", Order=1)]
		public  string gxTpr_Promocionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Promocionid, 9, 0));

			}
			set { 
				sdt.gxTpr_Promocionid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PromocionVigencia", Order=2)]
		public  string gxTpr_Promocionvigencia
		{
			get { 
				return sdt.gxTpr_Promocionvigencia;

			}
			set { 
				 sdt.gxTpr_Promocionvigencia = value;
			}
		}

		[DataMember(Name="PromocionBase", Order=3)]
		public  string gxTpr_Promocionbase
		{
			get { 
				return sdt.gxTpr_Promocionbase;

			}
			set { 
				 sdt.gxTpr_Promocionbase = value;
			}
		}

		[DataMember(Name="FacturaNo", Order=4)]
		public  string gxTpr_Facturano
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Facturano);

			}
			set { 
				 sdt.gxTpr_Facturano = value;
			}
		}

		[DataMember(Name="FacturaFechaFactura", Order=5)]
		public  string gxTpr_Facturafechafactura
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Facturafechafactura);

			}
			set { 
				sdt.gxTpr_Facturafechafactura = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ModeloID_Description", Order=6)]
		public  string gxTpr_Modeloid_description
		{
			get { 
				return sdt.gxTpr_Modeloid_description;

			}
			set { 
				 sdt.gxTpr_Modeloid_description = value;
			}
		}

		[DataMember(Name="ModeloID", Order=7, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Modeloid
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Modeloid_GxSimpleCollection_Json())
					return sdt.gxTpr_Modeloid.ToStringCollection(10, 0);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Modeloid.FromStringCollection(value);
			}
		}

		[DataMember(Name="FacturaPDF", Order=8)]
		[GxUpload()]
		public  string gxTpr_Facturapdf
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Facturapdf);

			}
			set { 
				 sdt.gxTpr_Facturapdf = value;
			}
		}


		#endregion

		public SdtWPFacturaWizardData_SelecPromo sdt
		{
			get { 
				return (SdtWPFacturaWizardData_SelecPromo)Sdt;
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
				sdt = new SdtWPFacturaWizardData_SelecPromo() ;
			}
		}
	}
	#endregion
}