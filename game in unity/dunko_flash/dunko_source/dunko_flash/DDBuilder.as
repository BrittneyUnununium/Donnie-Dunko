package  {
	
	import flash.display.MovieClip;
	
	
	public class DDBuilder extends MovieClip {
		
		import flash.events.*;
		import flash.display.Bitmap;
		import flash.display.BitmapData;
		
		public var charListXML:XML = null;
		/*
		<root>
			<char>
				<CID>1</CID>
				<name>joe</name>
				<head>1</head>
				<body>1</body>
			</char>
		</root>	
		*/

		private var serverData:MBDMobileData=null;				

		var sBody:Number=1;
		var sHead:Number=1;
					
		public function DDBuilder() {
			// constructor code
			trace("DDBuilder");
			
			serverData = new MBDMobileData(this);				
			
			this.addEventListener(Event.ADDED_TO_STAGE, addedToStage);							
			 
		}
		
		function addedToStage(e:Event):void {
			this.removeEventListener(Event.ADDED_TO_STAGE, addedToStage);							
			
			var headInst:AllHeads = new AllHeads();
			var totalHeads = headInst.totalFrames;
			
			myTileList.addEventListener(Event.CHANGE, thumbnailClicked); 

			
			for (var i = 1; i <= totalHeads; i++) {
				headInst.gotoAndStop(i);							
				var obj:Bitmap = getHead(headInst);
				myTileList.addItem({ data:i, source:obj});
			}
			
			// charListInst
			// addBtnInst
			
			charListInst.addEventListener(Event.CHANGE, cListClicked); 
			//parseCharList(charListXML);
			
			deleteBtnInst.addEventListener(MouseEvent.CLICK, doDelete); 
			addBtnInst.addEventListener(MouseEvent.CLICK, doAddChar); 
			
			b1Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b2Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b3Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b4Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b5Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b6Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b7Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b8Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b9Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 
			b10Inst.addEventListener(MouseEvent.CLICK, doBodyClick); 

			getChars();
		}
		
		function getHead(obj):Bitmap {
		    var bmd:BitmapData = new BitmapData(obj.width, obj.height);
    		var bm:Bitmap = new Bitmap(bmd);
    		bmd.draw(obj);
			//mcContainer.addChild(bm);

			return(bm);
		}

		function thumbnailClicked(event:Event):void { 
			//myUILoader.source=event.target.selectedItem.source; 
			//trace(event.target.selectedItem.data);
			if( event.target.selectedItem != null ) {
				sHead = event.target.selectedItem.data;
				headTxtInst.text = "Head: "+sHead;
				dudeInst.headInst.gotoAndStop(sHead);
			}
		} 		
		
		function cListClicked(event:Event):void { 
			//myUILoader.source=event.target.selectedItem.source; 
		trace(event.target.selectedItem.data);
			
		} 		
		
		function doDelete(event:MouseEvent):void { 		
			if( charListInst.selectedItem != null  ) {
				trace(charListInst.selectedItem.data);
				serverData.deleteChar(charListInst.selectedItem.data,deleteComplete);
				
			}
		} 		
		public function deleteComplete(cData:XML):void {
			getChars();
		}			
		
		function parseCharList(cListXML:XML):void {
			charListInst.dataProvider.removeAll();			
			
			for(var i:int=0; i<cListXML.char.length(); i++) {
				charListInst.addItem({label:cListXML.char[i].name, data:cListXML.char[i].CID});
			}
			
		}
		
		function doAddChar(event:MouseEvent):void { 
			trace("doAddChar");
						
			putChar();
			/*
			charListXML.appendChild(<char><CID>1</CID><name>{cNameInst.text}</name><head>{sHead}</head><body>{sBody}</body></char>)			
			parseCharList(charListXML);
			*/
			cNameInst.text = "";
			
			// %% send to server, and receive from server full list
			
		}
		
		function doBodyClick(event:MouseEvent):void { 
			switch( event.currentTarget.name ) {
				case "b1Inst":
					sBody = 1;
				break;
				case "b2Inst":
					sBody = 2;
				break;
				case "b3Inst":
					sBody = 3;
				break;
				case "b4Inst":
					sBody = 4;
				break;
				case "b5Inst":
					sBody = 5;
				break;
				case "b6Inst":
					sBody = 6;
				break;
				case "b7Inst":
					sBody = 7;
				break;				
				case "b8Inst":
					sBody = 8;
				break;			
				case "b9Inst":
					sBody = 9;
				break;							
				case "b10Inst":
					sBody = 10;
				break;											
			}
			bodyTxtInst.text = "Body: "+sBody;
			dudeInst.gotoAndStop(sBody);
			
		}

		public function getChars() {
			serverData.getChars(charsLoaded); 
		}		
		public function charsLoaded(cData:XML):void {
			charListXML = cData;
			parseCharList(charListXML);
		}
		public function putChar() {
			var obj:Object=new Object();
			obj.cname = cNameInst.text;
			obj.chead = sHead;
			obj.cbody = sBody;
			serverData.putChar(obj,charPut); 
		}		
		public function charPut(cData:XML):void {
			getChars();
		}	
		

	


/*
addEventListener(Event.ENTER_FRAME,myFunction);
function myFunction(event:Event) {
	trace("Do Something");
}
*/
	}
	
}
