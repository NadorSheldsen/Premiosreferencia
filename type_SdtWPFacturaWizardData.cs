/*
				   File: type_SdtWPFacturaWizardData
			Description: WPFacturaWizardData
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
	[XmlRoot(ElementName="WPFacturaWizardData")]
	[XmlType(TypeName="WPFacturaWizardData" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPFacturaWizardData : GxUserType
	{
		public SdtWPFacturaWizardData( )
		{
			/* Constructor for serialization */
		}

		public SdtWPFacturaWizardData(IGxContext context)
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
			if (gxTv_SdtWPFacturaWizardData_Selecpromo != null)
			{
				AddObjectProperty("SelecPromo", gxTv_SdtWPFacturaWizardData_Selecpromo, false);
			}
			if (gxTv_SdtWPFacturaWizardData_Selecmedidas != null)
			{
				AddObjectProperty("SelecMedidas", gxTv_SdtWPFacturaWizardData_Selecmedidas, false);
			}
			if (gxTv_SdtWPFacturaWizardData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWPFacturaWizardData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SelecPromo" )]
		[XmlElement(ElementName="SelecPromo" )]
		public SdtWPFacturaWizardData_SelecPromo gxTpr_Selecpromo
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_Selecpromo == null )
				{
					gxTv_SdtWPFacturaWizardData_Selecpromo = new SdtWPFacturaWizardData_SelecPromo(context);
				}
				gxTv_SdtWPFacturaWizardData_Selecpromo_N = false;
				return gxTv_SdtWPFacturaWizardData_Selecpromo;
			}
			set {
				gxTv_SdtWPFacturaWizardData_Selecpromo_N = false;
				gxTv_SdtWPFacturaWizardData_Selecpromo = value;
				SetDirty("Selecpromo");
			}

		}

		public void gxTv_SdtWPFacturaWizardData_Selecpromo_SetNull()
		{
			gxTv_SdtWPFacturaWizardData_Selecpromo_N = true;
			gxTv_SdtWPFacturaWizardData_Selecpromo = null;
		}

		public bool gxTv_SdtWPFacturaWizardData_Selecpromo_IsNull()
		{
			return gxTv_SdtWPFacturaWizardData_Selecpromo == null;
		}
		public bool ShouldSerializegxTpr_Selecpromo_Json()
		{
				return (gxTv_SdtWPFacturaWizardData_Selecpromo != null && gxTv_SdtWPFacturaWizardData_Selecpromo.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="SelecMedidas" )]
		[XmlElement(ElementName="SelecMedidas" )]
		public SdtWPFacturaWizardData_SelecMedidas gxTpr_Selecmedidas
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_Selecmedidas == null )
				{
					gxTv_SdtWPFacturaWizardData_Selecmedidas = new SdtWPFacturaWizardData_SelecMedidas(context);
				}
				gxTv_SdtWPFacturaWizardData_Selecmedidas_N = false;
				return gxTv_SdtWPFacturaWizardData_Selecmedidas;
			}
			set {
				gxTv_SdtWPFacturaWizardData_Selecmedidas_N = false;
				gxTv_SdtWPFacturaWizardData_Selecmedidas = value;
				SetDirty("Selecmedidas");
			}

		}

		public void gxTv_SdtWPFacturaWizardData_Selecmedidas_SetNull()
		{
			gxTv_SdtWPFacturaWizardData_Selecmedidas_N = true;
			gxTv_SdtWPFacturaWizardData_Selecmedidas = null;
		}

		public bool gxTv_SdtWPFacturaWizardData_Selecmedidas_IsNull()
		{
			return gxTv_SdtWPFacturaWizardData_Selecmedidas == null;
		}
		public bool ShouldSerializegxTpr_Selecmedidas_Json()
		{
				return (gxTv_SdtWPFacturaWizardData_Selecmedidas != null && gxTv_SdtWPFacturaWizardData_Selecmedidas.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_Auxiliardata == null )
				{
					gxTv_SdtWPFacturaWizardData_Auxiliardata = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWPFacturaWizardData_Auxiliardata;
			}
			set {
				gxTv_SdtWPFacturaWizardData_Auxiliardata_N = false;
				gxTv_SdtWPFacturaWizardData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWPFacturaWizardData_Auxiliardata == null )
				{
					gxTv_SdtWPFacturaWizardData_Auxiliardata = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWPFacturaWizardData_Auxiliardata_N = false;
				return gxTv_SdtWPFacturaWizardData_Auxiliardata ;
			}
			set {
				gxTv_SdtWPFacturaWizardData_Auxiliardata_N = false;
				gxTv_SdtWPFacturaWizardData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWPFacturaWizardData_Auxiliardata_SetNull()
		{
			gxTv_SdtWPFacturaWizardData_Auxiliardata_N = true;
			gxTv_SdtWPFacturaWizardData_Auxiliardata = null;
		}

		public bool gxTv_SdtWPFacturaWizardData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWPFacturaWizardData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWPFacturaWizardData_Auxiliardata != null && gxTv_SdtWPFacturaWizardData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Selecpromo_Json() ||
				ShouldSerializegxTpr_Selecmedidas_Json() ||
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
			gxTv_SdtWPFacturaWizardData_Selecpromo_N = true;


			gxTv_SdtWPFacturaWizardData_Selecmedidas_N = true;


			gxTv_SdtWPFacturaWizardData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWPFacturaWizardData_Selecpromo_N;
		protected SdtWPFacturaWizardData_SelecPromo gxTv_SdtWPFacturaWizardData_Selecpromo = null; 

		protected bool gxTv_SdtWPFacturaWizardData_Selecmedidas_N;
		protected SdtWPFacturaWizardData_SelecMedidas gxTv_SdtWPFacturaWizardData_Selecmedidas = null; 

		protected bool gxTv_SdtWPFacturaWizardData_Auxiliardata_N;
		protected GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWPFacturaWizardData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPFacturaWizardData", Namespace="Premios")]
	public class SdtWPFacturaWizardData_RESTInterface : GxGenericCollectionItem<SdtWPFacturaWizardData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPFacturaWizardData_RESTInterface( ) : base()
		{	
		}

		public SdtWPFacturaWizardData_RESTInterface( SdtWPFacturaWizardData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SelecPromo", Order=0, EmitDefaultValue=false)]
		public SdtWPFacturaWizardData_SelecPromo_RESTInterface gxTpr_Selecpromo
		{
			get {
				if (sdt.ShouldSerializegxTpr_Selecpromo_Json())
					return new SdtWPFacturaWizardData_SelecPromo_RESTInterface(sdt.gxTpr_Selecpromo);
				else
					return null;

			}

			set {
				sdt.gxTpr_Selecpromo = value.sdt;
			}

		}

		[DataMember(Name="SelecMedidas", Order=1, EmitDefaultValue=false)]
		public SdtWPFacturaWizardData_SelecMedidas_RESTInterface gxTpr_Selecmedidas
		{
			get {
				if (sdt.ShouldSerializegxTpr_Selecmedidas_Json())
					return new SdtWPFacturaWizardData_SelecMedidas_RESTInterface(sdt.gxTpr_Selecmedidas);
				else
					return null;

			}

			set {
				sdt.gxTpr_Selecmedidas = value.sdt;
			}

		}

		[DataMember(Name="AuxiliarData", Order=2, EmitDefaultValue=false)]
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

		public SdtWPFacturaWizardData sdt
		{
			get { 
				return (SdtWPFacturaWizardData)Sdt;
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
				sdt = new SdtWPFacturaWizardData() ;
			}
		}
	}
	#endregion
}