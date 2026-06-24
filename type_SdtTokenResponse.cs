/*
				   File: type_SdtTokenResponse
			Description: TokenResponse
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
	[XmlRoot(ElementName="TokenResponse")]
	[XmlType(TypeName="TokenResponse" , Namespace="Premios" )]
	[Serializable]
	public class SdtTokenResponse : GxUserType
	{
		public SdtTokenResponse( )
		{
			/* Constructor for serialization */
			gxTv_SdtTokenResponse_Token = "";

		}

		public SdtTokenResponse(IGxContext context)
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
			AddObjectProperty("status", gxTpr_Status, false);


			AddObjectProperty("token", gxTpr_Token, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="status")]
		[XmlElement(ElementName="status")]
		public bool gxTpr_Status
		{
			get {
				return gxTv_SdtTokenResponse_Status; 
			}
			set {
				gxTv_SdtTokenResponse_Status = value;
				SetDirty("Status");
			}
		}




		[SoapElement(ElementName="token")]
		[XmlElement(ElementName="token")]
		public string gxTpr_Token
		{
			get {
				return gxTv_SdtTokenResponse_Token; 
			}
			set {
				gxTv_SdtTokenResponse_Token = value;
				SetDirty("Token");
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
			gxTv_SdtTokenResponse_Token = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtTokenResponse_Status;
		 

		protected string gxTv_SdtTokenResponse_Token;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"TokenResponse", Namespace="Premios")]
	public class SdtTokenResponse_RESTInterface : GxGenericCollectionItem<SdtTokenResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTokenResponse_RESTInterface( ) : base()
		{	
		}

		public SdtTokenResponse_RESTInterface( SdtTokenResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="status", Order=0)]
		public bool gxTpr_Status
		{
			get { 
				return sdt.gxTpr_Status;

			}
			set { 
				sdt.gxTpr_Status = value;
			}
		}

		[DataMember(Name="token", Order=1)]
		public  string gxTpr_Token
		{
			get { 
				return sdt.gxTpr_Token;

			}
			set { 
				 sdt.gxTpr_Token = value;
			}
		}


		#endregion

		public SdtTokenResponse sdt
		{
			get { 
				return (SdtTokenResponse)Sdt;
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
				sdt = new SdtTokenResponse() ;
			}
		}
	}
	#endregion
}