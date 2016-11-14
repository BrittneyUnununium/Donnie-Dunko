package  {	
	//import flash.utils.Timer;
			
	public final class MBDMobileData {
		import flash.events.*;
		import flash.net.URLLoader;
		import flash.net.URLRequest;
		import flash.net.URLVariables;
		import flash.net.URLLoaderDataFormat;
		import flash.net.URLRequestMethod;		
		import flash.events.IOErrorEvent;
		import flash.events.SecurityErrorEvent;
		import com.adobe.crypto.*;
		import flash.display.Loader;
		
		import flash.net.*;
		import flash.utils.*;
	
		import flash.system.Capabilities;
				
		private var _mainRef:Object=null;
		private var ChatLineCount:String="0";
		private var refreshReturned:Boolean=true;
		
		include "globals.as";
	
		var req:URLRequest = new URLRequest(serverURL); 
		
		public var assetsFolder:String;
		
		private var assetsList:XMLList;
		private var totalAssetsSize:Number;
		private var totalDownloadedSize:Number=0;
		private var pCode:String;
		private var aCode:String;
			
		private var assetDownloadList:Array=null;
		
		private var userName:String="useru11Y4G2s";
		private var accessToken:String="fjkads897234a1lafj";				
		
		//private var userPassword:String="";
				
		public function MBDMobileData(mRef:Object) {
			// constructor code
			_mainRef = mRef;
					
		}

		function randomNumber(low:Number=0, high:Number=1):Number
		{
		  return Math.floor(Math.random() * (1+high-low)) + low;
		}
		

	// ********************************
	
		public function doServerMsg(msgType:String,msgData:Object,callBack:Object):void {
			var variables:URLVariables = new URLVariables();			
			var connectLoader:URLLoader = new URLLoader();						
			connectLoader.dataFormat = URLLoaderDataFormat.TEXT; // VARIABLES;
			req.method = URLRequestMethod.POST;
			variables.DDSERVICE = msgType;
			variables.UNAME = userName; // username of admin
			variables.PWORD = "lkKoirAfd"; // password of admin
			variables.ATOKEN = accessToken; // accessToken; access token of admin
			var vStr:String= "kfjew82uthsj"+variables.UNAME+variables.PWORD+variables.ATOKEN+"loe992u5hs"; // validator code
			var validatorStr:String = MD5.hash(vStr);									
			variables.VALIDATOR = validatorStr;
						
			switch(msgType) {				
				case "AdminDeleteCharacter": // language code
					variables.cid = msgData;
				break;							
				case "AdminPutCharacter": // language code
					variables.name = msgData.cname;
					variables.head = msgData.chead;
					variables.body = msgData.cbody;
				break;		
				case "GetCharacters":
					variables.CHARLIST = msgData;
				break;
				case "UpdateDunk": 			// language code
					variables.CID = msgData.cid;
					variables.WPID = msgData.wpid;
					variables.ACCESSKEY = msgData.accesskey;
				break;							
				case "DDLogin":
					variables.ACCESSKEY = msgData.accesskey;
					variables.WPID = msgData.wpid;
				break;				
			}
			
			req.data = variables;				
			//trace("doServerMsg data "+variables)
			connectLoader.addEventListener(Event.COMPLETE, onSendComplete);
			connectLoader.addEventListener(IOErrorEvent.IO_ERROR, onIOError );
			connectLoader.addEventListener(SecurityErrorEvent.SECURITY_ERROR,onSecurityError);
			
			try {
				connectLoader.load(req);				
			} catch(e:Error) { 
				trace("haveConnect error: "+e);
				removeListeners();
			} 
			
			function onSendComplete(e:Event):void
			{			
				trace(e.target.data);
				var resultXML:XML;
				var assetsXML:XML;			
				try 
				{
					resultXML =  XML(e.target.data);
					//trace("RESULT: "+resultXML);
					switch(String(resultXML.RESULT)) {						
						case 'SYSTEMERROR':
						case 'FAIL':
						case 'NORESULTS':
							trace("ERROR: "+resultXML);
							switch(msgType) {
								case "DDLogin":
									_mainRef.loginFailed();
								break								
							}							
						break;				
						case 'ERROR':
							trace("ERROR");
							assetsXML = XML(decodeURI(resultXML.RESULTXML));	
							trace("Server Error: "+assetsXML.MESSAGE);
						break;						
						case 'SUCCESS':
							//_mainRef.userLoginStage(true);
							//trace("SUCCESS");
							switch(msgType) {
								case "UpdateDunk":
								case "DDLogin":
								case "GetCharacters":								
								case "AdminDeleteCharacter":
								case "AdminGetCharacters":	
								case "AdminPutCharacter":	
								case "GetDunkList":
									assetsXML = XML(decodeURI(resultXML.RESULTXML));
									callBack(assetsXML);
								break								
							}					
						break;
						// dataCallBack( XML(decodeURI(resultXML.RESULTXML)) );						
						
					}					
				}
				catch (error:Error)
				{
					trace("Error:", error.message);
					_mainRef.doAlert("SERVERIOERROR");							
				}						
				removeListeners();
			}

			function onIOError(e:IOErrorEvent):void
			{			
				/*
				_mainRef.loadProgressInst.visible = false;
				_mainRef.loadProgressInst.progressBarInst.visible = true;
				_mainRef.loadProgressInst.pleaseWaitMsgInst.visible = false;		
				*/
				trace("onIOError");
				_mainRef.doAlert("SERVERIOERROR");					
				removeListeners();
			}			
			function onSecurityError(e:SecurityErrorEvent):void
			{			
				/*
				_mainRef.loadProgressInst.visible = false;
				_mainRef.loadProgressInst.progressBarInst.visible = true;
				_mainRef.loadProgressInst.pleaseWaitMsgInst.visible = false;									
				*/
				trace("onSecurityError");
				_mainRef.doAlert("SERVERIOERROR");					
				removeListeners();
			}						
			function removeListeners():void {
				connectLoader.removeEventListener(Event.COMPLETE, onSendComplete);
				connectLoader.removeEventListener(IOErrorEvent.IO_ERROR, onIOError );
				connectLoader.removeEventListener(SecurityErrorEvent.SECURITY_ERROR,onSecurityError);				
				connectLoader = null;
			}		
			
			
		}
		
		// ***

		public function getChars(callBackFunc:Object):void {
			trace("getChars");
			doServerMsg("AdminGetCharacters",null,callBackFunc)			
		}			
		
		public function putChar(dataObj:Object,callBackFunc:Object):void {
			trace("putChar: "+dataObj);
			doServerMsg("AdminPutCharacter",dataObj,callBackFunc)			
		}					
		
		public function deleteChar(dataObj:Object,callBackFunc:Object):void {
			trace("deleteChar: "+dataObj);
			doServerMsg("AdminDeleteCharacter",dataObj,callBackFunc)			
		}							


		public function getUserChars(cList:String,callBackFunc:Object):void {
			trace("getUserChars: "+cList);
			doServerMsg("GetCharacters",cList,callBackFunc)			
		}			
		public function updateDunk(dataObj:Object,callBackFunc:Object):void {
			trace("updateDunk: "+dataObj);
			doServerMsg("UpdateDunk",dataObj,callBackFunc)			
		}		
		
		public function login(dataObj:Object,callBackFunc:Object):void {
			trace("login: "+dataObj);
			doServerMsg("DDLogin",dataObj,callBackFunc)			
		}				
		
		//
		
		
		public function getDunkList(callBackFunc:Object):void {
			doServerMsg("GetDunkList",null,callBackFunc)			
		}			
		
	}	
}




