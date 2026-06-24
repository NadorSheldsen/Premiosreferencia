/*
				   File: type_SdtSDTSegmentos_Segmento
			Description: SDTSegmentos
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
	[XmlRoot(ElementName="Segmento")]
	[XmlType(TypeName="Segmento" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTSegmentos_Segmento : GxUserType
	{
		public SdtSDTSegmentos_Segmento( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSegmentos_Segmento_Segmento = "";

		}

		public SdtSDTSegmentos_Segmento(IGxContext context)
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
				return gxTv_SdtSDTSegmentos_Segmento_Segmento; 
			}
			set {
				gxTv_SdtSDTSegmentos_Segmento_Segmento = value;
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
			gxTv_SdtSDTSegmentos_Segmento_Segmento = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTSegmentos_Segmento_Segmento;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Segmento", Namespace="Premios")]
	public class SdtSDTSegmentos_Segmento_RESTInterface : GxGenericCollectionItem<SdtSDTSegmentos_Segmento>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSegmentos_Segmento_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSegmentos_Segmento_RESTInterface( SdtSDTSegmentos_Segmento psdt ) : base(psdt)
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

		public SdtSDTSegmentos_Segmento sdt
		{
			get { 
				return (SdtSDTSegmentos_Segmento)Sdt;
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
				sdt = new SdtSDTSegmentos_Segmento() ;
			}
		}
	}
	#endregion
}