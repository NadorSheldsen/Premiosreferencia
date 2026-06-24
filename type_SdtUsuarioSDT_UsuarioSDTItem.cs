/*
				   File: type_SdtUsuarioSDT_UsuarioSDTItem
			Description: UsuarioSDT
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
	[XmlRoot(ElementName="UsuarioSDTItem")]
	[XmlType(TypeName="UsuarioSDTItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtUsuarioSDT_UsuarioSDTItem : GxUserType
	{
		public SdtUsuarioSDT_UsuarioSDTItem( )
		{
			/* Constructor for serialization */
		}

		public SdtUsuarioSDT_UsuarioSDTItem(IGxContext context)
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
			AddObjectProperty("UsuarioID", gxTpr_Usuarioid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UsuarioID")]
		[XmlElement(ElementName="UsuarioID")]
		public int gxTpr_Usuarioid
		{
			get {
				return gxTv_SdtUsuarioSDT_UsuarioSDTItem_Usuarioid; 
			}
			set {
				gxTv_SdtUsuarioSDT_UsuarioSDTItem_Usuarioid = value;
				SetDirty("Usuarioid");
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

		protected int gxTv_SdtUsuarioSDT_UsuarioSDTItem_Usuarioid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"UsuarioSDTItem", Namespace="Premios")]
	public class SdtUsuarioSDT_UsuarioSDTItem_RESTInterface : GxGenericCollectionItem<SdtUsuarioSDT_UsuarioSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtUsuarioSDT_UsuarioSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtUsuarioSDT_UsuarioSDTItem_RESTInterface( SdtUsuarioSDT_UsuarioSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UsuarioID", Order=0)]
		public  string gxTpr_Usuarioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Usuarioid, 9, 0));

			}
			set { 
				sdt.gxTpr_Usuarioid = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtUsuarioSDT_UsuarioSDTItem sdt
		{
			get { 
				return (SdtUsuarioSDT_UsuarioSDTItem)Sdt;
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
				sdt = new SdtUsuarioSDT_UsuarioSDTItem() ;
			}
		}
	}
	#endregion
}