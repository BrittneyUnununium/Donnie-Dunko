package  {
	
	import flash.display.MovieClip;
	import flash.events.MouseEvent;
	
	
	public class DonnieDunko extends MovieClip {
		
		import com.adobe.serialization.json.JSON;
		import caurina.transitions.Tweener;
		import flash.events.*;
		import flash.profiler.showRedrawRegions;
		import flash.external.*;
		import flash.display.*;
		
		import flash.net.URLRequest;
		import flash.net.navigateToURL;
		
		var holdingBall:Boolean=false;
		
		var targetHitSndInst:TargetHitSnd = new TargetHitSnd();
		var dunkBellSndInst:DunkBellSnd = new DunkBellSnd();
		var tankHitSndInst:TankHitSnd = new TankHitSnd();
		
		var thudHitSndInst:ThudHitSnd = new ThudHitSnd();
		
		private var serverData:MBDMobileData=null;			
		
		public var charListXML:XML = null;
		private var selectedCID:Number=0;
		private var dunkDone:Boolean = false;
		private var dunkCounter:Number = 3;
		
		private var globalLoaderInfo:LoaderInfo;
		private var flashParams:Object;
		private var accesskey:String="none";
		private var wpid:String="0";		
		
		public function DonnieDunko() {
			globalLoaderInfo = loaderInfo;
			flashParams = globalLoaderInfo.parameters;
			var fullurl:String = ExternalInterface.call("window.location.href.toString");
			//launchLocation = globalLoaderInfo.url;			
			
			trace("flashParams: "+JSON.encode(flashParams));
			trace("external: "+fullurl);
			trace("WPID: "+flashParams.wpid);
			
			//trace("launchLocation: "+launchLocation);				
			//trace("call external");			
			
			// constructor code
			//showRedrawRegions ( true, 0x0000FF );
			enterNameInst.visible = false;
			gameOverInst.visible = false;
			
			gameOverInst.playAgainBtnInst.addEventListener(MouseEvent.CLICK,doPlayAgain);
			gameOverInst.playAgainBtnInst.buttonMode = true;
			
			trace("Dunk");
			mainTankInst.dunkeeInst.gotoAndStop(8);
			mainTankInst.dunkeeInst.dunkeeIndividualInst.headInst.gotoAndStop(1);
			

			mainTankInst.mouseChildren = false;

			// headInst		
			
			/*
			mainInst.dudeInst.headInst.gotoAndStop(3);
			mainInst.dudeInst.lowerArmsInst.gotoAndStop(2);
			mainInst.dudeInst.bodyInst.gotoAndStop(2);					
			*/
			
			// targetInst.addEventListener(MouseEvent.CLICK,doTarget);
			ballInst.addEventListener(MouseEvent.MOUSE_DOWN,doBallGrab);
			
			mainTankInst.dunkeeInst.visible = false;
			charSelectPopupInst.playBtnInst.visible = false;
			serverData = new MBDMobileData(this);		
			
			charSelectPopupInst.playBtnInst.addEventListener(MouseEvent.CLICK,doPlay);			
			charSelectPopupInst.charListInst.addEventListener(Event.CHANGE, cListClicked); 
						
			if(fullurl){
				var params:Array = fullurl.split('?');
				if( params[1] != undefined ) {
					fullurl = params[1];
					params = fullurl.split('&');
					var length:uint = params.length;
					var g:uint;
					for (g=0; g< length; g++){
						var index:int=0;
						var kvPair:String = params[g];
						if((index = kvPair.indexOf("=")) > 0){
							var key:String = kvPair.substring(0,index);
							var value:String = kvPair.substring(index+1);
							params[key] = value;
						}
					}				
					if( params["chars"] != undefined ) {
						// params["chars"];
						//trace("chars: "+params["chars"]);
					}					
					if( params["accesskey"] != undefined ) {
						// validate key
						// params["accesskey"];
						accesskey = params["accesskey"];
						//trace("accesskey: "+params["accesskey"]);
					}
					/*
					if( params["wpid"] != undefined ) {
						wpid = params["wpid"];
					}	
					*/
				}
				if( flashParams.wpid != undefined ) {
					wpid = flashParams.wpid;
				}
				
			}
			
			// http://s365653042.onlinehome.us/donniedunko/play?chars=0&accesskey=txn_id

			var uObj:Object=new Object();
			uObj.accesskey = accesskey;
			uObj.wpid = wpid;			
			serverData.login(uObj,loginComplete);
						
		}
						
		public function loginComplete(cData:XML):void {		
			var charList:String;
			trace("loginComplete");
			dunkCounter = cData.DUNKS;			
						
			if( ( (accesskey=="none") && (wpid == "0") ) || (dunkCounter==0) ) {
				dunkCounter = 1;
				charList="120";
			} else {				
				charList=cData.CHARLIST;
			}
			
			
			getUserChars(charList);
		}
		
		public function loginFailed():void {
			trace("loginFailed");
			getUserChars("120"); // only download 1 character, and 1 dunk
			dunkCounter = 1;

		}
		
		function doPlay(e:MouseEvent):void {
			charSelectPopupInst.visible = false;
			
			if( (selectedCID==1) || (selectedCID==2) ) {
				enterNameInst.visible = true;
				enterNameInst.nameEnterBtnInst.addEventListener(MouseEvent.CLICK,doNameEntered);							
				stage.focus = enterNameInst.enterNameTxtInst;
			}
			
		}
		function doPlayAgain(e:MouseEvent):void {		
			// old var link:URLRequest = new URLRequest("http://s365653042.onlinehome.us/donniedunko/");
			var link:URLRequest = new URLRequest("http://donniedunko.com/");
			navigateToURL(link, "_self");							
		}
		
		
		function doNameEntered(event:Event):void { 
			var newName:String;
			enterNameInst.nameEnterBtnInst.removeEventListener(MouseEvent.CLICK,doNameEntered);							
			nameTagInst.nameTagTxtInst.text = enterNameInst.enterNameTxtInst.text;
			//nameTagInst.nameTagTxtInst.text = newName;
			enterNameInst.visible = false;			
		}
		
		function cListClicked(event:Event):void { 
			//myUILoader.source=event.target.selectedItem.source; 
			if( event.target.selectedItem != null ) {				
				selectedCID = event.target.selectedItem.data;
				mainTankInst.gotoAndStop(1);
				
				trace( charListXML.char.(CID==selectedCID).body );
				trace( charListXML.char.(CID==selectedCID).head );
				mainTankInst.dunkeeInst.gotoAndStop( charListXML.char.(CID==selectedCID).body );
				mainTankInst.dunkeeInst.dunkeeIndividualInst.headInst.gotoAndStop( charListXML.char.(CID==selectedCID).head );
				nameTagInst.nameTagTxtInst.text = charListXML.char.(CID==selectedCID).name;
				mainTankInst.dunkeeInst.visible = true;
				charSelectPopupInst.playBtnInst.visible = true;
			}
						
		}		
			
		function doBallGrab(e:MouseEvent):void {
			holdingBall = true;
			this.addEventListener(MouseEvent.MOUSE_MOVE,doBallMove);
			this.addEventListener(MouseEvent.MOUSE_UP,doBallRelease);
			ballInst.scaleX = 1.2;
			ballInst.scaleY = 1.2;						
		}
		function doBallMove(e:MouseEvent):void {
			e.stopPropagation();
			ballInst.x = this.mouseX;
			ballInst.y = this.mouseY;
		}
		
		function doBallRelease(e:MouseEvent):void {
			var tComplete = function() { 
				/*
				ballInst.scaleX = 1;
				ballInst.scaleY = 1;		
				ballInst.x = 681.15;
				ballInst.y = 499.45;
				*/
				if (ballInst.hitTestObject(targetInst))
				 {
					doTarget(null);
					ballInst.scaleX = 0.75;
					ballInst.scaleY = 0.75;						
					Tweener.addTween(targetInst, {scaleX:0.8, scaleY:0.8, time:0.75, transition:"easeOutElastic"});
					Tweener.addTween(ballInst, {y: 430, time:0.50, transition:"easeOutBounce"});
					Tweener.addTween(ballInst, {x: 790, rotation:630, time:2, transition:"linear",onComplete:tComplete2});				  
				 } else {
					 if (ballInst.hitTestObject(mainTankInst.tubHitTestInst)) {
						 tankHitSndInst.play();
						//Tweener.addTween(ballInst, {y: 0, time:0.50, transition:"linear"});					 
						Tweener.addTween(ballInst, {x: 0, y:randomRange(50,550), scaleX:1, scaleY:1, rotation:-630, time:0.25, transition:"linear",onComplete:tComplete2});				  
					 } else {					
					 	thudHitSndInst.play();
					 	ballInst.scaleX = 0.75;
						ballInst.scaleY = 0.75;						
						Tweener.addTween(ballInst, {y: 430, time:0.50, transition:"linear"});					 
						Tweener.addTween(ballInst, {x: 790, rotation:630, time:2, transition:"linear",onComplete:tComplete2});				  
					 }
				 }

			};
			var tComplete2 = function() { 
				ballInst.scaleX = 1;
				ballInst.scaleY = 1;		
				ballInst.x = 681.15;
				ballInst.y = 499.45;
				ballInst.rotation = 0; // randomRange(0,180);
				Tweener.addTween(targetInst, {scaleX:1, scaleY:1, time:0.75, transition:"easeOutElastic"});
				if (dunkDone == true ) {
					dunkCounter -= 1;
					if( dunkCounter > 0 ) {
						dunkDone = false;
						charSelectPopupInst.visible = true;				
						//mainTankInst.dunkeeInst.visible = false;
						charSelectPopupInst.charListInst.selectedIndex = -1;
						charSelectPopupInst.playBtnInst.visible = false;
					} else {
						// game over
						gameOverInst.visible = true;
					}
				}
				
			};			
			
			holdingBall = false;
			this.removeEventListener(MouseEvent.MOUSE_MOVE,doBallMove);
			this.removeEventListener(MouseEvent.MOUSE_UP,doBallRelease);			
			ballInst.gotoAndPlay(2);
			Tweener.addTween(ballInst, {scaleX: 0.40, scaleY:0.40, time:0.25, transition:"linear",onComplete:tComplete});
		}
		function randomRange(minNum:Number, maxNum:Number):Number   
		{  
			return (Math.floor(Math.random() * (maxNum - minNum + 1)) + minNum);  
		}  		
		function doTarget(e:MouseEvent):void {
			dunkDone = true;
			targetHitSndInst.play();
			//dunkBellSndInst.play();
			mainTankInst.gotoAndPlay(2);
			mainTankInst.dunkeeInst.dunkeeIndividualInst.gotoAndPlay(2);
			//mainInst.gotoAndPlay(1);
			//mainInst.dudeInst.gotoAndPlay(1);
			var uObj:Object=new Object();
			uObj.cid = selectedCID;
			uObj.wpid = wpid;
			uObj.accesskey = accesskey;
			serverData.updateDunk(uObj,dunkUpdated);
		}		
		
		function dunkUpdated(cData:XML):void {
			//
			trace("dunkUpdated");
		}		
		
		public function getUserChars(charList:String) {
			serverData.getUserChars(charList,charsLoaded); 
		}		
		public function charsLoaded(cData:XML):void {
			trace("charsLoaded");
			charListXML = cData;
			parseCharList(cData);			
		}

		function parseCharList(cListXML:XML):void {
			charSelectPopupInst.charListInst.dataProvider.removeAll();						
			for(var i:int=0; i<cListXML.char.length(); i++) {
				charSelectPopupInst.charListInst.addItem({label:cListXML.char[i].name+" - Dunks: "+charListXML.char[i].dunkcount, data:cListXML.char[i].CID});
			}			
		}
		
		
	}	
}


