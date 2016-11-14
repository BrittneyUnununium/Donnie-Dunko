// ActionScript file

import flash.system.Security;

//static private var siteDomain:String="www.moxiebot.com";
// old static private var siteDomain:String="s365653042.onlinehome.us/donniedunko";
static private var siteDomain:String="donniedunko.com";

[Bindable]
public var serverURL : String = "http://"+siteDomain+"/ddbootstrap.php";

Security.allowDomain( siteDomain );