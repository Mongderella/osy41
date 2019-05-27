﻿try{
	////----------------------
	////PC-WEB EGS SETTING
	////----------------------
	var _egsAppName = "mobile_app";
    var _egsAgent = navigator.userAgent.toLowerCase();
    var _egsIsApp = (_egsAgent.indexOf(_egsAppName) > -1) ? true : _egsAgent.indexOf("interparkbrowser-shop") > -1 ? true : false;
    var _egsLoc = window.location.href.toLowerCase();


    var _egsAction;
    var _egsSite = "tour.pcweb";

    //EGS ACTION TAG SETTING
    if(_egsLoc.indexOf("TOUR.THETRAVEL.CO.KR/gate/login") > -1){
        _egsAction = "login";
    }
    else if(_egsLoc.indexOf("air.interpark.com") > -1 || _egsLoc.indexOf("domair.interpark.com") > -1 || _egsLoc.indexOf("fly.interpark.com") > -1 )
    {
        _egsAction = "air";
        // _egsSite = "air.pcweb";
    }
    else if(_egsLoc.indexOf("housing.interpark.com") > -1 || _egsLoc.indexOf("TOUR.THETRAVEL.CO.KR/housing") > -1 || _egsLoc.indexOf("hotel.interpark.com") > -1 || _egsLoc.indexOf("TOUR.THETRAVEL.CO.KR/airtel") > -1)
    {
        _egsAction = "hotel";
        // _egsSite = "hotel.pcweb";
    }
    else {
        _egsAction = "tour";
        // _egsSite = "tour.pcweb";
    }

    //App
    if(_egsIsApp){
        //EGS M_PCID SETTING
        if (__egsUtil.cookies.get("appInfo") != "" && __egsUtil.cookies.get('m_pcid') != "") {
            var _appInfo = __egsUtil.cookies.get("appInfo").split(/@@|\|/);
            if (_appInfo[3] != "") {
                _data_pcid = _appInfo[3];
                __egsUtil.cookies.set('m_pcid', _data_pcid, { "expires": new Date(2100, 1, 1), "path": "/", "domain": "interpark.com" });
                EsLogMinor._PCID = _data_pcid;
            }
        }
        //EGS SITE SETTING
        if (_egsAgent.indexOf("interparkbrowser-shop") > -1) {
            _egsSite = "interpark.app";//인터파크 통합앱
        }
        //EGS SITE SETTING
        else if(_egsAgent.indexOf("interparktourair") > -1)
        {
            _egsSite = "air.app";//항공 앱
        }
        else if(_egsAgent.indexOf("interparktourabroadhotel") > -1 ){
            _egsSite = "hotel.app";//해외호텔 앱
        }
        else if(_egsAgent.indexOf("interparktourcheckinnow") > -1 ){
            _egsSite = "checkinnow.app";//체크인나우 앱
        }
        else if(_egsAgent.indexOf("interparktourmain") > -1){
            _egsSite = "tour.app";//인터파크 투어앱
        }
        else{
            _egsSite = "others.app";
        }
    }

    var __EGS_DATAOBJ = {
        "tagging" : "tour.action.view",
        "action" : _egsAction,
        "site" : _egsSite
    };
    EsLogMinor.sendLog(); 
}catch(e){};
