/*
				   File: type_SdtSDTModelos_SDTModelosItem
			Description: SDTModelos
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
	[XmlRoot(ElementName="SDTModelosItem")]
	[XmlType(TypeName="SDTModelosItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTModelos_SDTModelosItem : GxUserType
	{
		public SdtSDTModelos_SDTModelosItem( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTModelos_SDTModelosItem(IGxContext context)
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
			AddObjectProperty("ModeloID", gxTpr_Modeloid, false);


			AddObjectProperty("PromocionModeloPrecio", gxTpr_Promocionmodeloprecio, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ModeloID")]
		[XmlElement(ElementName="ModeloID")]
		public int gxTpr_Modeloid
		{
			get {
				return gxTv_SdtSDTModelos_SDTModelosItem_Modeloid; 
			}
			set {
				gxTv_SdtSDTModelos_SDTModelosItem_Modeloid = value;
				SetDirty("Modeloid");
			}
		}



		[SoapElement(ElementName="PromocionModeloPrecio")]
		[XmlElement(ElementName="PromocionModeloPrecio")]
		public string gxTpr_Promocionmodeloprecio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTModelos_SDTModelosItem_Promocionmodeloprecio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTModelos_SDTModelosItem_Promocionmodeloprecio = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Promocionmodeloprecio
		{
			get {
				return gxTv_SdtSDTModelos_SDTModelosItem_Promocionmodeloprecio; 
			}
			set {
				gxTv_SdtSDTModelos_SDTModelosItem_Promocionmodeloprecio = value;
				SetDirty("Promocionmodeloprecio");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTModelos_SDTModelosItem_Modeloid;
		 

		protected decimal gxTv_SdtSDTModelos_SDTModelosItem_Promocionmodeloprecio;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTModelosItem", Namespace="Premios")]
	public class SdtSDTModelos_SDTModelosItem_RESTInterface : GxGenericCollectionItem<SdtSDTModelos_SDTModelosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTModelos_SDTModelosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTModelos_SDTModelosItem_RESTInterface( SdtSDTModelos_SDTModelosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ModeloID", Order=0)]
		public  string gxTpr_Modeloid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Modeloid, 9, 0));

			}
			set { 
				sdt.gxTpr_Modeloid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PromocionModeloPrecio", Order=1)]
		public  string gxTpr_Promocionmodeloprecio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Promocionmodeloprecio, 10, 2));

			}
			set { 
				sdt.gxTpr_Promocionmodeloprecio =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTModelos_SDTModelosItem sdt
		{
			get { 
				return (SdtSDTModelos_SDTModelosItem)Sdt;
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
				sdt = new SdtSDTModelos_SDTModelosItem() ;
			}
		}
	}
	#endregion
}