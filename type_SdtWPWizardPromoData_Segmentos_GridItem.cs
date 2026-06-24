/*
				   File: type_SdtWPWizardPromoData_Segmentos_GridItem
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
	[XmlRoot(ElementName="WPWizardPromoData.Segmentos.GridItem")]
	[XmlType(TypeName="WPWizardPromoData.Segmentos.GridItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtWPWizardPromoData_Segmentos_GridItem : GxUserType
	{
		public SdtWPWizardPromoData_Segmentos_GridItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPWizardPromoData_Segmentos_GridItem_Segmento = "";

		}

		public SdtWPWizardPromoData_Segmentos_GridItem(IGxContext context)
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
			AddObjectProperty("Segmento", gxTpr_Segmento, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Segmento")]
		[XmlElement(ElementName="Segmento")]
		public string gxTpr_Segmento
		{
			get {
				return gxTv_SdtWPWizardPromoData_Segmentos_GridItem_Segmento; 
			}
			set {
				gxTv_SdtWPWizardPromoData_Segmentos_GridItem_Segmento = value;
				SetDirty("Segmento");
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
			gxTv_SdtWPWizardPromoData_Segmentos_GridItem_Segmento = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWPWizardPromoData_Segmentos_GridItem_Segmento;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WPWizardPromoData.Segmentos.GridItem", Namespace="Premios")]
	public class SdtWPWizardPromoData_Segmentos_GridItem_RESTInterface : GxGenericCollectionItem<SdtWPWizardPromoData_Segmentos_GridItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPWizardPromoData_Segmentos_GridItem_RESTInterface( ) : base()
		{	
		}

		public SdtWPWizardPromoData_Segmentos_GridItem_RESTInterface( SdtWPWizardPromoData_Segmentos_GridItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Segmento", Order=0)]
		public  string gxTpr_Segmento
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Segmento);

			}
			set { 
				 sdt.gxTpr_Segmento = value;
			}
		}


		#endregion

		public SdtWPWizardPromoData_Segmentos_GridItem sdt
		{
			get { 
				return (SdtWPWizardPromoData_Segmentos_GridItem)Sdt;
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
				sdt = new SdtWPWizardPromoData_Segmentos_GridItem() ;
			}
		}
	}
	#endregion
}