/*
				   File: type_SdtSDTToken
			Description: SDTToken
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
	[XmlRoot(ElementName="SDTToken")]
	[XmlType(TypeName="SDTToken" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTToken : GxUserType
	{
		public SdtSDTToken( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTToken_Jwt = "";

		}

		public SdtSDTToken(IGxContext context)
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
			AddObjectProperty("jwt", gxTpr_Jwt, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="jwt")]
		[XmlElement(ElementName="jwt")]
		public string gxTpr_Jwt
		{
			get {
				return gxTv_SdtSDTToken_Jwt; 
			}
			set {
				gxTv_SdtSDTToken_Jwt = value;
				SetDirty("Jwt");
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
			gxTv_SdtSDTToken_Jwt = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTToken_Jwt;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTToken", Namespace="Premios")]
	public class SdtSDTToken_RESTInterface : GxGenericCollectionItem<SdtSDTToken>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTToken_RESTInterface( ) : base()
		{	
		}

		public SdtSDTToken_RESTInterface( SdtSDTToken psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="jwt", Order=0)]
		public  string gxTpr_Jwt
		{
			get { 
				return sdt.gxTpr_Jwt;

			}
			set { 
				 sdt.gxTpr_Jwt = value;
			}
		}


		#endregion

		public SdtSDTToken sdt
		{
			get { 
				return (SdtSDTToken)Sdt;
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
				sdt = new SdtSDTToken() ;
			}
		}
	}
	#endregion
}