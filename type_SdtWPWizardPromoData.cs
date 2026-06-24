/*
				   File: type_SdtWPWizardPromoData
			Description: WPWizardPromoData
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
	[XmlRoot(ElementName="WPWizardPromoData")]
	[XmlType(TypeName="WPWizardPromoData" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPWizardPromoData : GxUserType
	{
		public SdtWPWizardPromoData( )
		{
			/* Constructor for serialization */
		}

		public SdtWPWizardPromoData(IGxContext context)
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
			if (gxTv_SdtWPWizardPromoData_Infogeneral != null)
			{
				AddObjectProperty("InfoGeneral", gxTv_SdtWPWizardPromoData_Infogeneral, false);
			}
			if (gxTv_SdtWPWizardPromoData_Segmentos != null)
			{
				AddObjectProperty("Segmentos", gxTv_SdtWPWizardPromoData_Segmentos, false);
			}
			if (gxTv_SdtWPWizardPromoData_Modelos != null)
			{
				AddObjectProperty("Modelos", gxTv_SdtWPWizardPromoData_Modelos, false);
			}
			if (gxTv_SdtWPWizardPromoData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWPWizardPromoData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="InfoGeneral" )]
		[XmlElement(ElementName="InfoGeneral" )]
		public SdtWPWizardPromoData_InfoGeneral gxTpr_Infogeneral
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_Infogeneral == null )
				{
					gxTv_SdtWPWizardPromoData_Infogeneral = new SdtWPWizardPromoData_InfoGeneral(context);
				}
				gxTv_SdtWPWizardPromoData_Infogeneral_N = false;
				return gxTv_SdtWPWizardPromoData_Infogeneral;
			}
			set {
				gxTv_SdtWPWizardPromoData_Infogeneral_N = false;
				gxTv_SdtWPWizardPromoData_Infogeneral = value;
				SetDirty("Infogeneral");
			}

		}

		public void gxTv_SdtWPWizardPromoData_Infogeneral_SetNull()
		{
			gxTv_SdtWPWizardPromoData_Infogeneral_N = true;
			gxTv_SdtWPWizardPromoData_Infogeneral = null;
		}

		public bool gxTv_SdtWPWizardPromoData_Infogeneral_IsNull()
		{
			return gxTv_SdtWPWizardPromoData_Infogeneral == null;
		}
		public bool ShouldSerializegxTpr_Infogeneral_Json()
		{
				return (gxTv_SdtWPWizardPromoData_Infogeneral != null && gxTv_SdtWPWizardPromoData_Infogeneral.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Segmentos" )]
		[XmlElement(ElementName="Segmentos" )]
		public SdtWPWizardPromoData_Segmentos gxTpr_Segmentos
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_Segmentos == null )
				{
					gxTv_SdtWPWizardPromoData_Segmentos = new SdtWPWizardPromoData_Segmentos(context);
				}
				gxTv_SdtWPWizardPromoData_Segmentos_N = false;
				return gxTv_SdtWPWizardPromoData_Segmentos;
			}
			set {
				gxTv_SdtWPWizardPromoData_Segmentos_N = false;
				gxTv_SdtWPWizardPromoData_Segmentos = value;
				SetDirty("Segmentos");
			}

		}

		public void gxTv_SdtWPWizardPromoData_Segmentos_SetNull()
		{
			gxTv_SdtWPWizardPromoData_Segmentos_N = true;
			gxTv_SdtWPWizardPromoData_Segmentos = null;
		}

		public bool gxTv_SdtWPWizardPromoData_Segmentos_IsNull()
		{
			return gxTv_SdtWPWizardPromoData_Segmentos == null;
		}
		public bool ShouldSerializegxTpr_Segmentos_Json()
		{
				return (gxTv_SdtWPWizardPromoData_Segmentos != null && gxTv_SdtWPWizardPromoData_Segmentos.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Modelos" )]
		[XmlElement(ElementName="Modelos" )]
		public SdtWPWizardPromoData_Modelos gxTpr_Modelos
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_Modelos == null )
				{
					gxTv_SdtWPWizardPromoData_Modelos = new SdtWPWizardPromoData_Modelos(context);
				}
				gxTv_SdtWPWizardPromoData_Modelos_N = false;
				return gxTv_SdtWPWizardPromoData_Modelos;
			}
			set {
				gxTv_SdtWPWizardPromoData_Modelos_N = false;
				gxTv_SdtWPWizardPromoData_Modelos = value;
				SetDirty("Modelos");
			}

		}

		public void gxTv_SdtWPWizardPromoData_Modelos_SetNull()
		{
			gxTv_SdtWPWizardPromoData_Modelos_N = true;
			gxTv_SdtWPWizardPromoData_Modelos = null;
		}

		public bool gxTv_SdtWPWizardPromoData_Modelos_IsNull()
		{
			return gxTv_SdtWPWizardPromoData_Modelos == null;
		}
		public bool ShouldSerializegxTpr_Modelos_Json()
		{
				return (gxTv_SdtWPWizardPromoData_Modelos != null && gxTv_SdtWPWizardPromoData_Modelos.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_Auxiliardata == null )
				{
					gxTv_SdtWPWizardPromoData_Auxiliardata = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWPWizardPromoData_Auxiliardata;
			}
			set {
				gxTv_SdtWPWizardPromoData_Auxiliardata_N = false;
				gxTv_SdtWPWizardPromoData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWPWizardPromoData_Auxiliardata == null )
				{
					gxTv_SdtWPWizardPromoData_Auxiliardata = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWPWizardPromoData_Auxiliardata_N = false;
				return gxTv_SdtWPWizardPromoData_Auxiliardata ;
			}
			set {
				gxTv_SdtWPWizardPromoData_Auxiliardata_N = false;
				gxTv_SdtWPWizardPromoData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWPWizardPromoData_Auxiliardata_SetNull()
		{
			gxTv_SdtWPWizardPromoData_Auxiliardata_N = true;
			gxTv_SdtWPWizardPromoData_Auxiliardata = null;
		}

		public bool gxTv_SdtWPWizardPromoData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWPWizardPromoData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWPWizardPromoData_Auxiliardata != null && gxTv_SdtWPWizardPromoData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Infogeneral_Json() ||
				ShouldSerializegxTpr_Segmentos_Json() ||
				ShouldSerializegxTpr_Modelos_Json() ||
				 ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()||  
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
			gxTv_SdtWPWizardPromoData_Infogeneral_N = true;


			gxTv_SdtWPWizardPromoData_Segmentos_N = true;


			gxTv_SdtWPWizardPromoData_Modelos_N = true;


			gxTv_SdtWPWizardPromoData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWPWizardPromoData_Infogeneral_N;
		protected SdtWPWizardPromoData_InfoGeneral gxTv_SdtWPWizardPromoData_Infogeneral = null; 

		protected bool gxTv_SdtWPWizardPromoData_Segmentos_N;
		protected SdtWPWizardPromoData_Segmentos gxTv_SdtWPWizardPromoData_Segmentos = null; 

		protected bool gxTv_SdtWPWizardPromoData_Modelos_N;
		protected SdtWPWizardPromoData_Modelos gxTv_SdtWPWizardPromoData_Modelos = null; 

		protected bool gxTv_SdtWPWizardPromoData_Auxiliardata_N;
		protected GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWPWizardPromoData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPWizardPromoData", Namespace="Premios")]
	public class SdtWPWizardPromoData_RESTInterface : GxGenericCollectionItem<SdtWPWizardPromoData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPWizardPromoData_RESTInterface( ) : base()
		{	
		}

		public SdtWPWizardPromoData_RESTInterface( SdtWPWizardPromoData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="InfoGeneral", Order=0, EmitDefaultValue=false)]
		public SdtWPWizardPromoData_InfoGeneral_RESTInterface gxTpr_Infogeneral
		{
			get {
				if (sdt.ShouldSerializegxTpr_Infogeneral_Json())
					return new SdtWPWizardPromoData_InfoGeneral_RESTInterface(sdt.gxTpr_Infogeneral);
				else
					return null;

			}

			set {
				sdt.gxTpr_Infogeneral = value.sdt;
			}

		}

		[DataMember(Name="Segmentos", Order=1, EmitDefaultValue=false)]
		public SdtWPWizardPromoData_Segmentos_RESTInterface gxTpr_Segmentos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Segmentos_Json())
					return new SdtWPWizardPromoData_Segmentos_RESTInterface(sdt.gxTpr_Segmentos);
				else
					return null;

			}

			set {
				sdt.gxTpr_Segmentos = value.sdt;
			}

		}

		[DataMember(Name="Modelos", Order=2, EmitDefaultValue=false)]
		public SdtWPWizardPromoData_Modelos_RESTInterface gxTpr_Modelos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Modelos_Json())
					return new SdtWPWizardPromoData_Modelos_RESTInterface(sdt.gxTpr_Modelos);
				else
					return null;

			}

			set {
				sdt.gxTpr_Modelos = value.sdt;
			}

		}

		[DataMember(Name="AuxiliarData", Order=3, EmitDefaultValue=false)]
		public  GxGenericCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface> gxTpr_Auxiliardata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json())
					return new GxGenericCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface>(sdt.gxTpr_Auxiliardata);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Auxiliardata);
			}
		}


		#endregion

		public SdtWPWizardPromoData sdt
		{
			get { 
				return (SdtWPWizardPromoData)Sdt;
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
				sdt = new SdtWPWizardPromoData() ;
			}
		}
	}
	#endregion
}