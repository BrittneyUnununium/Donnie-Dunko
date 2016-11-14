package  {
	
	import flash.display.MovieClip;
	
	
	public class DunkRanking extends MovieClip {
		
		import flash.text.*;
		
		private var serverData:MBDMobileData=null;		
		public var charListXML:XML = null;
		
		
		public function DunkRanking() {
			serverData = new MBDMobileData(this);		
			serverData.getDunkList(charsLoaded); 
		}
		
		public function charsLoaded(cData:XML):void {
			trace("charsLoaded:"+cData);
			charListXML = cData;
			parseCharList(cData);			
		}
		

		function parseCharList(cListXML:XML):void {
			var font:TextFormat = new TextFormat();
			font.size = 18;
			font.color = 0x000000;
			font.leading = 8;

			charListTxtInst.setStyle("textFormat", font);
			charListTxtInst.text="";
			for(var i:int=0; i<cListXML.char.length(); i++) {
				charListTxtInst.appendText( cListXML.char[i].name+" - Dunks: "+charListXML.char[i].dunkcount+"\n");
			}			
		}		
		
	}	
}
