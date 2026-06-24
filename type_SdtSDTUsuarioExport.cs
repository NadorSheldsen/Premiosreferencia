/*
				   File: type_SdtSDTUsuarioExport
			Description: SDTUsuarioExport
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
	[XmlRoot(ElementName="SDTUsuarioExport")]
	[XmlType(TypeName="SDTUsuarioExport" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTUsuarioExport : GxUserType
	{
		public SdtSDTUsuarioExport( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTUsuarioExport_Email = "";

			gxTv_SdtSDTUsuarioExport_Name = "";

			gxTv_SdtSDTUsuarioExport_Firstname = "";

			gxTv_SdtSDTUsuarioExport_Lastname = "";

		}

		public SdtSDTUsuarioExport(IGxContext context)
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
			AddObjectProperty("email", gxTpr_Email, false);


			AddObjectProperty("name", gxTpr_Name, false);


			AddObjectProperty("firstName", gxTpr_Firstname, false);


			AddObjectProperty("lastName", gxTpr_Lastname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="email")]
		[XmlElement(ElementName="email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSDTUsuarioExport_Email; 
			}
			set {
				gxTv_SdtSDTUsuarioExport_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTUsuarioExport_Name; 
			}
			set {
				gxTv_SdtSDTUsuarioExport_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="firstName")]
		[XmlElement(ElementName="firstName")]
		public string gxTpr_Firstname
		{
			get {
				return gxTv_SdtSDTUsuarioExport_Firstname; 
			}
			set {
				gxTv_SdtSDTUsuarioExport_Firstname = value;
				SetDirty("Firstname");
			}
		}




		[SoapElement(ElementName="lastName")]
		[XmlElement(ElementName="lastName")]
		public string gxTpr_Lastname
		{
			get {
				return gxTv_SdtSDTUsuarioExport_Lastname; 
			}
			set {
				gxTv_SdtSDTUsuarioExport_Lastname = value;
				SetDirty("Lastname");
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
			gxTv_SdtSDTUsuarioExport_Email = "";
			gxTv_SdtSDTUsuarioExport_Name = "";
			gxTv_SdtSDTUsuarioExport_Firstname = "";
			gxTv_SdtSDTUsuarioExport_Lastname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTUsuarioExport_Email;
		 

		protected string gxTv_SdtSDTUsuarioExport_Name;
		 

		protected string gxTv_SdtSDTUsuarioExport_Firstname;
		 

		protected string gxTv_SdtSDTUsuarioExport_Lastname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTUsuarioExport", Namespace="Premios")]
	public class SdtSDTUsuarioExport_RESTInterface : GxGenericCollectionItem<SdtSDTUsuarioExport>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTUsuarioExport_RESTInterface( ) : base()
		{	
		}

		public SdtSDTUsuarioExport_RESTInterface( SdtSDTUsuarioExport psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="email", Order=0)]
		public  string gxTpr_Email
		{
			get { 
				return sdt.gxTpr_Email;

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="firstName", Order=2)]
		public  string gxTpr_Firstname
		{
			get { 
				return sdt.gxTpr_Firstname;

			}
			set { 
				 sdt.gxTpr_Firstname = value;
			}
		}

		[DataMember(Name="lastName", Order=3)]
		public  string gxTpr_Lastname
		{
			get { 
				return sdt.gxTpr_Lastname;

			}
			set { 
				 sdt.gxTpr_Lastname = value;
			}
		}


		#endregion

		public SdtSDTUsuarioExport sdt
		{
			get { 
				return (SdtSDTUsuarioExport)Sdt;
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
				sdt = new SdtSDTUsuarioExport() ;
			}
		}
	}
	#endregion
}