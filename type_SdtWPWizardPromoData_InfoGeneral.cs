/*
				   File: type_SdtWPWizardPromoData_InfoGeneral
			Description: InfoGeneral
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
	[XmlRoot(ElementName="WPWizardPromoData.InfoGeneral")]
	[XmlType(TypeName="WPWizardPromoData.InfoGeneral" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPWizardPromoData_InfoGeneral : GxUserType
	{
		public SdtWPWizardPromoData_InfoGeneral( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPWizardPromoData_InfoGeneral_Promodescripcion = "";

			gxTv_SdtWPWizardPromoData_InfoGeneral_Promobase = "";

			gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_description = "";

			gxTv_SdtWPWizardPromoData_InfoGeneral_Promoarte = "";

		}

		public SdtWPWizardPromoData_InfoGeneral(IGxContext context)
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
			AddObjectProperty("PromoDescripcion", gxTpr_Promodescripcion, false);


			AddObjectProperty("PromoBase", gxTpr_Promobase, false);


			AddObjectProperty("DistribuidorID_Description", gxTpr_Distribuidorid_description, false);

			if (gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid != null)
			{
				AddObjectProperty("DistribuidorID", gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid, false);
			}

			AddObjectProperty("PromoArte", gxTpr_Promoarte, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Iniciopromo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Iniciopromo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Iniciopromo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("InicioPromo", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Finpromo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Finpromo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Finpromo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FinPromo", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PromoDescripcion")]
		[XmlElement(ElementName="PromoDescripcion")]
		public string gxTpr_Promodescripcion
		{
			get {
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Promodescripcion; 
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Promodescripcion = value;
				SetDirty("Promodescripcion");
			}
		}




		[SoapElement(ElementName="PromoBase")]
		[XmlElement(ElementName="PromoBase")]
		public string gxTpr_Promobase
		{
			get {
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Promobase; 
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Promobase = value;
				SetDirty("Promobase");
			}
		}




		[SoapElement(ElementName="DistribuidorID_Description")]
		[XmlElement(ElementName="DistribuidorID_Description")]
		public string gxTpr_Distribuidorid_description
		{
			get {
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_description; 
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_description = value;
				SetDirty("Distribuidorid_description");
			}
		}




		[SoapElement(ElementName="DistribuidorID" )]
		[XmlArray(ElementName="DistribuidorID"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<int> gxTpr_Distribuidorid_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid == null )
				{
					gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid = new GxSimpleCollection<int>( );
				}
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid;
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_N = false;
				gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<int> gxTpr_Distribuidorid
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid == null )
				{
					gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid = new GxSimpleCollection<int>();
				}
				gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_N = false;
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid ;
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_N = false;
				gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid = value;
				SetDirty("Distribuidorid");
			}
		}

		public void gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_SetNull()
		{
			gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_N = true;
			gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid = null;
		}

		public bool gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_IsNull()
		{
			return gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid == null;
		}
		public bool ShouldSerializegxTpr_Distribuidorid_GxSimpleCollection_Json()
		{
			return gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid != null && gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid.Count > 0;

		}

		[SoapElement(ElementName="PromoArte")]
		[XmlElement(ElementName="PromoArte")]
		[GxUpload()]
		public byte[] gxTpr_Promoarte_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtWPWizardPromoData_InfoGeneral_Promoarte) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtWPWizardPromoData_InfoGeneral_Promoarte=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Promoarte
		{
			get {
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Promoarte; 
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Promoarte = value;
				SetDirty("Promoarte");
			}
		}



		[SoapElement(ElementName="InicioPromo")]
		[XmlElement(ElementName="InicioPromo" , IsNullable=true)]
		public string gxTpr_Iniciopromo_Nullable
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_InfoGeneral_Iniciopromo == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPWizardPromoData_InfoGeneral_Iniciopromo).value ;
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Iniciopromo = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Iniciopromo
		{
			get {
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Iniciopromo; 
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Iniciopromo = value;
				SetDirty("Iniciopromo");
			}
		}


		[SoapElement(ElementName="FinPromo")]
		[XmlElement(ElementName="FinPromo" , IsNullable=true)]
		public string gxTpr_Finpromo_Nullable
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_InfoGeneral_Finpromo == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPWizardPromoData_InfoGeneral_Finpromo).value ;
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Finpromo = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Finpromo
		{
			get {
				return gxTv_SdtWPWizardPromoData_InfoGeneral_Finpromo; 
			}
			set {
				gxTv_SdtWPWizardPromoData_InfoGeneral_Finpromo = value;
				SetDirty("Finpromo");
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
			gxTv_SdtWPWizardPromoData_InfoGeneral_Promodescripcion = "";
			gxTv_SdtWPWizardPromoData_InfoGeneral_Promobase = "";
			gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_description = "";

			gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_N = true;

			gxTv_SdtWPWizardPromoData_InfoGeneral_Promoarte = "";


			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtWPWizardPromoData_InfoGeneral_Promodescripcion;
		 

		protected string gxTv_SdtWPWizardPromoData_InfoGeneral_Promobase;
		 

		protected string gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_description;
		 
		protected bool gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid_N;
		protected GxSimpleCollection<int> gxTv_SdtWPWizardPromoData_InfoGeneral_Distribuidorid = null;  

		protected string gxTv_SdtWPWizardPromoData_InfoGeneral_Promoarte;
		 

		protected DateTime gxTv_SdtWPWizardPromoData_InfoGeneral_Iniciopromo;
		 

		protected DateTime gxTv_SdtWPWizardPromoData_InfoGeneral_Finpromo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPWizardPromoData.InfoGeneral", Namespace="Premios")]
	public class SdtWPWizardPromoData_InfoGeneral_RESTInterface : GxGenericCollectionItem<SdtWPWizardPromoData_InfoGeneral>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPWizardPromoData_InfoGeneral_RESTInterface( ) : base()
		{	
		}

		public SdtWPWizardPromoData_InfoGeneral_RESTInterface( SdtWPWizardPromoData_InfoGeneral psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PromoDescripcion", Order=0)]
		public  string gxTpr_Promodescripcion
		{
			get { 
				return sdt.gxTpr_Promodescripcion;

			}
			set { 
				 sdt.gxTpr_Promodescripcion = value;
			}
		}

		[DataMember(Name="PromoBase", Order=1)]
		public  string gxTpr_Promobase
		{
			get { 
				return sdt.gxTpr_Promobase;

			}
			set { 
				 sdt.gxTpr_Promobase = value;
			}
		}

		[DataMember(Name="DistribuidorID_Description", Order=2)]
		public  string gxTpr_Distribuidorid_description
		{
			get { 
				return sdt.gxTpr_Distribuidorid_description;

			}
			set { 
				 sdt.gxTpr_Distribuidorid_description = value;
			}
		}

		[DataMember(Name="DistribuidorID", Order=3, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Distribuidorid
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Distribuidorid_GxSimpleCollection_Json())
					return sdt.gxTpr_Distribuidorid.ToStringCollection(10, 0);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Distribuidorid.FromStringCollection(value);
			}
		}

		[DataMember(Name="PromoArte", Order=4)]
		[GxUpload()]
		public  string gxTpr_Promoarte
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Promoarte);

			}
			set { 
				 sdt.gxTpr_Promoarte = value;
			}
		}

		[DataMember(Name="InicioPromo", Order=5)]
		public  string gxTpr_Iniciopromo
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Iniciopromo);

			}
			set { 
				sdt.gxTpr_Iniciopromo = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="FinPromo", Order=6)]
		public  string gxTpr_Finpromo
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Finpromo);

			}
			set { 
				sdt.gxTpr_Finpromo = DateTimeUtil.CToD2(value);
			}
		}


		#endregion

		public SdtWPWizardPromoData_InfoGeneral sdt
		{
			get { 
				return (SdtWPWizardPromoData_InfoGeneral)Sdt;
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
				sdt = new SdtWPWizardPromoData_InfoGeneral() ;
			}
		}
	}
	#endregion
}