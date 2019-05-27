/* 
 * *********************************************************************************************** //
 * MODIFIED DATE    : 2016-02-17 ( CREATED - 자유 여행 개편 )
 * MODIFIER         : DAN LEE
 * DESCRIPTION      : Commmon Functions
 *                    
 * *********************************************************************************************** //
*/
    

/* INITIALIZE - Objective Functions */
var _common =
{
    ANIMATION_TIME: 300,
    ANIMATION_TIME_MEDIUM: 500,
    LOADING_IMAGE_URL: 'http://openimage.interpark.com/tourpark/tour/free/etc/ajax-loader.gif',

    // Layer 팝업 오픈 시, 오픈 주체(element)의 id 를 저장 ( Layer 가 닫힐 때 Focus 를 돌려주기 위함 )
    LAYER_POPUP_OPENER_ID : '',

    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.IsMobileDevice();
    // *********************************************************************************************** //
    IsMobileDevice: function(){
        /// <summary>현재 Browser 가 모바일 기기의 것인지 여부를 판별하고 Boolean 으로 반환합니다.</summary>
        /// <returns type="Boolean">true / false</returns>

        if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent))
            return true;
        else
            return false;

    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.DetachLoadingImage('imgLoading');
    // *********************************************************************************************** //
    DetachLoadingImage: function ( lodingImgId ) {
        /// <summary>Baackgournd 와 함께 loading 이미지를 화면에 표시합니다.</summary>
        /// <param name="targetObjId" type="String">loading 이미지를 삽입할 대상 element id</param>
        /// <param name="lodingImgId" type="String">loading 이미지 객체에 할당할 id</param>
        /// <returns type=""></returns>


        // 로딩 객체가 존재하면 숨김
        if ( jQuery( '#' + lodingImgId ).length > 0 ) {
            jQuery( '#' + lodingImgId ).slideUp( _common.ANIMATION_TIME );
        }
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.AttachLoadingImage('targetObjId', 'imgLoading');
    // *********************************************************************************************** //
    AttachLoadingImage: function ( targetObjId, lodingImgId, style ) {
        /// <summary>Baackgournd 와 함께 loading 이미지를 화면에 표시합니다.</summary>
        /// <param name="targetObjId" type="String">loading 이미지를 삽입할 대상 element id</param>
        /// <param name="lodingImgId" type="String">loading 이미지 객체에 할당할 id</param>
        /// <param name="style" type="String">loading 이미지 객체에 할당할 style</param>
        /// <returns type=""></returns>


        var loadImg = null;

        // 로딩 객체가 존재하지 않으면 추가
        if ( jQuery( '#' + lodingImgId ).length == 0) {
            loadImg = jQuery( '<img id="' + lodingImgId + '" src="' + _common.LOADING_IMAGE_URL + '" style="width: 14px;' + style + '" />' )
            jQuery( '#' + targetObjId ).append( loadImg );
        }
        else
            loadImg = jQuery( '#' + lodingImgId );

        loadImg.hide();
        loadImg.slideDown( _common.ANIMATION_TIME );
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.HideLoadingImage();
    // *********************************************************************************************** //
    HideLoadingImage: function () {
        /// <summary>현재 표시되고 있는 loding 이미지를 화면에서 제거합니다.</summary>
        /// <returns type=""></returns>


        jQuery( '#imgLoading' ).hide();
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.ShowLoadingImage();
    // *********************************************************************************************** //
    ShowLoadingImage: function ()
    {
        /// <summary>loading 이미지를 화면에 표시합니다.</summary>
        /// <returns type=""></returns>


        if ( jQuery( '#imgLoading' ).length == 0 ) {
            jQuery('body').append('<img id="imgLoading" src="' + _common.LOADING_IMAGE_URL + '" style="width: 26px;" alt="로딩중"/>');
        }
        else {
            jQuery( 'body' ).append( jQuery( '#imgLoading' ) );
        }

        _common.ShowCenterPopupLayerWithZindex( 'imgLoading', 89 );
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.PrintElement('objName');
    // *********************************************************************************************** //
    PrintElement: function (id)
    {
        /// <summary>인자에 해당하는 Element 를 인쇄</summary>
        /// <param name="id" type="String">인쇄할 Div Element ID</param>
        /// <returns type=""></returns>


        var headstr = "<html><head><title></title></head><body>";
        var footstr = "</body>";
        var newstr = document.all.item( id ).innerHTML;
        var oldstr = document.body.innerHTML;
        document.body.innerHTML = headstr + newstr + footstr;
        window.print();

        // 프린트 후, 최상단으로 위치한 스크롤을 재조정
        setTimeout(function (e){
            location.href = '#' + id;
        }, 1000 );

        document.body.innerHTML = oldstr;
        return false;
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.ReleaseMouseBlock();
    // *********************************************************************************************** //
    ReleaseMouseBlock: function ()
    {
        document.onselectstart = null;
        document.onmousedown = null;
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.AddHyphenToDateString('20150821', '-');
    // *********************************************************************************************** //
    AddDelimiterToDateString: function ( dateStr, delimiter )
    {
        /// <summary>일반 8자리 Date String 을 yyyy-MM-dd 형태로 변환</summary>
        /// <param name="dateStr" type="String">yyyyMMdd 형태의 Date String</param>
        /// <param name="delimiter" type="String">구분 기호 문자</param>
        /// <returns type="String">Hyphen 이 들어간 형태의 Date String 문자열 ( yyyy-MM-dd )</returns>


        var returnResult = '';

        try
        {
            //var tmpDate = new Date( dateStr.substr( 0, 4 ) + '/' + dateStr.substr( 4, 2 ) + '/' + dateStr.substr( 6, 2 ) );

            returnResult = dateStr.substr( 0, 4 ) + '-' + dateStr.substr( 4, 2 ) + '-' + dateStr.substr( 6, 2 );
        }
        catch(ex)
        {
            returnResult = '';
        }

        return returnResult;
    },
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.DateToString(targetDate);
    // *********************************************************************************************** //
    DateToString: function ( date )
    {
        /// <summary>Date Type 인자를 String (yyyyMMdd) 형태로 치환</summary>
        /// <param name="date" type="Date">Date Type 변수</param>
        /// <returns type="String">String Type 으로 변환된 날짜 형식</returns>


        var d = new Date( date ),
            month = '' + ( d.getMonth() + 1 ),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if ( month.length < 2 ) month = '0' + month;
        if ( day.length < 2 ) day = '0' + day;

        return [year, month, day].join( '' );

    },
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.ShowCenterPopupLayer('divCenter', false);
    // *********************************************************************************************** //
    ShowCenterPopupLayer: function (idAndOpenerID, isWithBackground)
    {
        /// <summary>id 에 해당하는 Layer 를 화면 중앙에 표시</summary>
        /// <param name="id" type="String">숨길 Object ID | Layer 닫을 때 Focus 돌려줄 Object ID</param>
        /// <param name="isWithBackground" type="Boolean">Layer 를 표시할 때 Background 함께 표시 여부</param>
        /// <returns type=""></returns>

        // idAndOpenerID  숨길 Object ID | Layer 닫을 때 Focus 돌려줄 Object ID
        var paramDatas = idAndOpenerID.split('|');

        // id  = 기존 DIV id,  returnFocusID = Layer 를 닫고나서 Focus return 할 Object ID
        var id = paramDatas[0];
        var returnFocusID = paramDatas[1];  // 없을 경우 undefined

        var objLayer = jQuery( '#' + id );
        var objWidth = objLayer.width();
        var objHeight = objLayer.height();
        objLayer.css({ position: 'fixed', left: '50%', top: '50%', zIndex: 100, margin : '-' + objHeight / 2 + 'px 0px 0px ' + '-' +objWidth / 2 + 'px'
        })

        jQuery( "#" + id ).fadeIn( _common.ANIMATION_TIME );

        if (typeof isWithBackground == 'undefined' || typeof isWithBackground == true)
            _common.ShowBackgroundLayer();
        
        // Layer 오픈 시, Layer 내부 Focusable Element 에 Focus 
        if (typeof returnFocusID != 'undefined')
            $j('#' + id).find(':focusable').first().focus()

        // returnFocusID 가 있을 경우 global에 담아서 Layer 닫는 function에서 값을 사용할 수 있다.
        if (returnFocusID != undefined && returnFocusID != '') {
            _common.LAYER_POPUP_OPENER_ID = returnFocusID;
        }
    },
    ShowCenterPopupLayerWithZindex: function (id, zIndexValue, isWithBackground)
    {
        /// <summary>id 에 해당하는 Layer 를 화면 중앙에 표시</summary>
        /// <param name="id" type="String">숨길 Object ID</param>
        /// <param name="isWithBackground" type="Boolean">Layer 를 표시할 때 Background 함께 표시 여부</param>
        /// <returns type=""></returns>


        var objLayer = jQuery( '#' + id );
        var objWidth = objLayer.width();
        var objHeight = objLayer.height();
        objLayer.css( {
            position: 'fixed', left: '50%', top: '50%', zIndex: zIndexValue, margin: '-' + objHeight / 2 + 'px 0px 0px ' + '-' + objWidth / 2 + 'px'
        })

        jQuery( "#" + id ).fadeIn( _common.ANIMATION_TIME );

        if (typeof isWithBackground == 'undefined' || typeof isWithBackground == true)
            _common.ShowBackgroundLayer();
    }
    , ShowCenterPopupLayer_fix: function (idAndOpenerID, isWithBackground)
    {
        /// <summary>id 에 해당하는 Layer 를 화면 중앙에 표시 ( 고정형 )</summary>
        /// <param name="idAndOpenerID" type="String">숨길 Object ID | Layer 닫을 때 Focus 돌려줄 Object ID</param>
        /// <param name="isWithBackground" type="Boolean">Layer 를 표시할 때 Background 함께 표시 여부</param>
        /// <returns type=""></returns>

        // idAndOpenerID  숨길 Object ID | Layer 닫을 때 Focus 돌려줄 Object ID
        var paramDatas = idAndOpenerID.split('|');

        // id  = 기존 DIV id,  returnFocusID = Layer 를 닫고나서 Focus return 할 Object ID
        var id = paramDatas[0];
        var returnFocusID = paramDatas[1];  // 없을 경우 undefined

        jQuery( "body" ).append( jQuery( '#' + id ) );

        jQuery( "#" + id ).css( "top", ( jQuery( window ).height() - jQuery( "#" + id ).height() ) / 2 + jQuery( window ).scrollTop() + "px" );
        jQuery( "#" + id ).css( "left", ( jQuery( window ).width() - jQuery( "#" + id ).width() ) / 2 + jQuery( window ).scrollLeft() + "px" );

        jQuery("#" + id).css("position", "absolute");
        jQuery("#" + id).css("z-Index", "100");
        jQuery( "#" + id ).fadeIn( _common.ANIMATION_TIME );

        if (typeof isWithBackground == 'undefined' || typeof isWithBackground == true)
            _common.ShowBackgroundLayer();

        // Layer 오픈 시, Layer 내부 Focusable Element 에 Focus 
        if (typeof returnFocusID != 'undefined')
            $j('#' + id).find(':focusable').first().focus()

        // returnFocusID 가 있을 경우 global에 담아서 Layer 닫는 function에서 값을 사용할 수 있다.
        if (returnFocusID != undefined && returnFocusID != '') {
            _common.LAYER_POPUP_OPENER_ID = returnFocusID;
        }

    }
    , ShowCenterPopupLayerWithZindex_fix: function (id, zIndexValue, isWithBackground) {
        /// <summary>id 에 해당하는 Layer 를 화면 중앙에 표시 ( 고정형 )</summary>
        /// <param name="id" type="String">숨길 Object ID</param>
        /// <param name="isWithBackground" type="Boolean">Layer 를 표시할 때 Background 함께 표시 여부</param>
        /// <returns type=""></returns>


        jQuery( "body" ).append( jQuery( '#' + id ) );

        jQuery( "#" + id ).css( "top", ( jQuery( window ).height() - jQuery( "#" + id ).height() ) / 2 + jQuery( window ).scrollTop() + "px" );
        jQuery( "#" + id ).css( "left", ( jQuery( window ).width() - jQuery( "#" + id ).width() ) / 2 + jQuery( window ).scrollLeft() + "px" );

        jQuery( "#" + id ).css( "position", "absolute" );
        jQuery( "#" + id ).css( "z-Index", zIndexValue );
        jQuery( "#" + id ).fadeIn( _common.ANIMATION_TIME );

        if (typeof isWithBackground == 'undefined' || typeof isWithBackground == true)
            _common.ShowBackgroundLayer();
    }
    , ShowCenterPopupLayer_fix2: function (id, isWithBackground) {
        /// <summary>id 에 해당하는 Layer 를 화면 중앙에 표시 ( 고정형 )</summary>
        /// <param name="id" type="String">숨길 Object ID</param>
        /// <param name="isWithBackground" type="Boolean">Layer 를 표시할 때 Background 함께 표시 여부</param>
        /// <returns type=""></returns>


        //jQuery( ".event-wrap" ).append( jQuery( '#' + id ) );

        jQuery("#" + id).css("top", jQuery(window).scrollTop() - 800 + "px");
        jQuery("#" + id).css("left", (jQuery(window).width() - jQuery("#" + id).width()) / 2 + jQuery(window).scrollLeft() + "px");

        jQuery("#" + id).css("position", "absolute");
        jQuery("#" + id).fadeIn(_common.ANIMATION_TIME);

        if (typeof isWithBackground == 'undefined' || typeof isWithBackground == true)
            _common.ShowBackgroundLayer();
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.HideLayerWithBackground();
    // *********************************************************************************************** //
    HideLayerWithBackground: function ( id )
    {
        /// <summary>id 에 해당하는 Layer 를 숨김</summary>
        /// <param name="id" type="String">숨길 Object ID</param>
        /// <returns type=""></returns>


        //if ( jQuery( '#divBackGround' ) != null || typeof jQuery( '#divBackGround' ) != 'undefined' )
        if ( jQuery( '#divBackGround' ).length > 0)
            jQuery( "#divBackGround" ).fadeOut( _common.ANIMATION_TIME );

        jQuery("#" + id).fadeOut(_common.ANIMATION_TIME);

        if (_common.LAYER_POPUP_OPENER_ID != '') {
            $j('#' + _common.LAYER_POPUP_OPENER_ID).focus();
            _common.LAYER_POPUP_OPENER_ID = '';
        }
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.ShowBackgroundLayer();
    // *********************************************************************************************** //
    ShowBackgroundLayer: function ()
    {
        /// <summary>Background 를 어둡게 처리</summary>
        /// <returns type=""></returns>


        var backgroundElement = '<div id="divBackGround" style="position:absolute;left:0;top:0;z-index:90;display:none;background-color:#000000;width:100%;height:100%;opacity:0.7;filter:alpha(opacity=50);"></div>';

        if ( jQuery( '#divBackGround' ).length == 0)
            jQuery( 'body' ).append( backgroundElement );

        jQuery( "#divBackGround" ).css( "height", jQuery( 'body' ).prop( "scrollHeight" ) + "px" );
        jQuery( "#divBackGround" ).fadeIn(_common.ANIMATION_TIME);

    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.AppShareKakaoTalk('http://TOUR.THETRAVEL.CO.KR/event/event_view.aspx?seq=7641'
    //                                      , 'http://openimage.interpark.com/tourpark/tour/mobile/150303_KaKaoTalk.jpg')
    //                                      , '[봄여행 추천 이벤트]\n살랑살랑 봄여행 어디로 떠나볼까?');
    // *********************************************************************************************** //
    AppShareKakaoTalk: function ( shareUrl, text, imgPath )
    {
        /// <summary>KAKAO TALK 공유 ( APP )</summary>
        /// <param name="shareUrl" type="String">공유 대상 URL</param>
        /// <param name="text" type="String">공유 문구</param>
        /// <param name="imgPath" type="String">공유 컨텐츠에 표시될 이미지 경로</param>
        /// <returns type=""></returns>


        // 공유 문구 + 공유 url 합치기
        var sumText = text + "\n" + shareUrl;

        if ( _appName != '' )
            appShare( 'kakaotalk', sumText, shareUrl, imgPath, "" );
        else
        {
            //SendKakaotalk(msg, url, appName, img);

            Kakao.Link.sendTalkLink( {
                //label: "[" + appName + "]" + "\r\n" + msg,
                label: sumText + "\r\n",
                installTalk: true,

                image: {
                    src: imgPath,
                    width: '200',
                    height: '200'
                }
            } );
        }
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.kakaoStory('http://TOUR.THETRAVEL.CO.KR/event/event_view.aspx?seq=7641')
    //                               , '[봄여행 추천 이벤트]\n살랑살랑 봄여행 어디로 떠나볼까?');
    // *********************************************************************************************** //
    kakaoStory: function ( shareUrl, text )
    {
        /// <summary>KAKAO STORY 공유 ( PC )</summary>
        /// <param name="shareUrl" type="String">공유 대상 URL</param>
        /// <param name="text" type="String">공유 문구</param>
        /// <returns type=""></returns>


        Kakao.Auth.getStatus( function ( obj )
        {
            if ( obj.status == "connected" )
            {
                KakaoStoryShare();
            }
            else
            {
                Kakao.Auth.login( {			//카카오 스토리 로그인
                    success: function ( obj ) { KakaoStoryShare( shareUrl, text ); },
                    fail: function ( obj ) { alert( '카카오 스토리 연동 오류 : ' + obj.error ); }
                } );
            }
        } );
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.AppFacebookshare('http://TOUR.THETRAVEL.CO.KR/event/event_view.aspx?seq=7641'
    //                                     , '[봄여행 추천 이벤트]', '살랑살랑 봄여행 어디로 떠나볼까?'
    //                                     , 'http://openimage.interpark.com/tourpark/tour/mobile/150303_facebookBn.jpg');
    // *********************************************************************************************** //
    AppFacebookShare: function ( shareUrl, titleText, descText, imgPath )
    {
        /// <summary>FACEBOOK 공유 ( APP )</summary>
        /// <param name="shareUrl" type="String">공유 대상 URL</param>
        /// <param name="titleText" type="String">페북 공유 시, Bold 처리되어 나타나는 Contents 제목</param>
        /// <param name="descText" type="String">페북 공유 시, 제목 하단부에 gray color 로 표시되는 컨텐츠 상세 요약 문구</param>
        /// <param name="imgPath" type="String">페북 공유 시, 표시되는 Thumbnail 이미지 경로</param>
        /// <returns type=""></returns>


        appShare( "facebook", titleText, shareUrl, imgPath, descText );
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.FacebookShareDefault('http://TOUR.THETRAVEL.CO.KR/event/event_view.aspx?seq=7641'
    //                                         , '[봄여행 추천 이벤트]');
    // *********************************************************************************************** //
    FacebookShareDefault: function ( shareUrl, title )
    {
        /// <summary>FACEBOOK 공유 ( PC )</summary>
        /// <param name="shareUrl" type="String">공유 대상 URL</param>
        /// <param name="title" type="String">공유 이름 ( 공유 시, 활용되지 않음 )</param>
        /// <returns type=""></returns>


        var targetUrl = "http://www.facebook.com/sharer.php?s=100&p[url]=" + shareUrl + "&p[title]=" + encodeURIComponent( title );
        var option = "menubar=no, toolbar=no, location=no, status=no, scrollbars=no, width=594, height=311";

        window.open( targetUrl, 'facebookShare', option );
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.FacebookShareDefault('http://TOUR.THETRAVEL.CO.KR/event/event_view.aspx?seq=7641'
    //                                         , '[봄여행 추천 이벤트]');
    // *********************************************************************************************** //
    FacebookShareMobileWeb: function ( shareUrl, title )
    {
        /// <summary>FACEBOOK 공유 ( Mobile Web ) * iOS 의 경우 User action이 있을 때 popup ( window.open )을 띄우는 것은 허용 *</summary>
        /// <param name="shareUrl" type="String">공유 대상 URL</param>
        /// <param name="title" type="String">공유 이름 ( 공유 시, 활용되지 않음 )</param>
        /// <returns type=""></returns>


        window.open( "http://www.facebook.com/sharer.php?u=" + encodeURIComponent( shareUrl ) + "&t=" + title, '_blank' );
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.bookmarksite("http://TOUR.THETRAVEL.CO.KR"
    //                                 , "인터파크투어 이벤트 - 누가 좀 정해줘요! '봄여행'");
    // *********************************************************************************************** //
    bookmarksite: function ( url, title )
    {
        /// <summary>즐겨찾기 추가</summary>
        /// <param name="url" type="String">북마크할 URL    </param>
        /// <param name="title" type="String">북마크명</param>
        /// <returns type=""></returns>


        // Internet Explorer 11
        if ( navigator.appName == 'Netscape' && navigator.userAgent.search( 'Trident' ) != -1 )
        {
            window.external.AddFavorite( url, title );
        }
            // Internet Explorer 
        else if ( document.all )
        {
            window.external.AddFavorite( url, title );
        }
            // Google Chrome 
        else if ( window.chrome )
        {
            alert( "Ctrl+D키를 누르시면 즐겨찾기에 추가하실 수 있습니다." );
        }
            // Firefox 
        else if ( window.sidebar ) // firefox 
        {
            window.sidebar.addPanel( title, url, "" );
        }
            // Opera 
        else if ( window.opera && window.print )
        {
            var elem = document.createElement( 'a' );
            elem.setAttribute( 'href', url );
            elem.setAttribute( 'title', title );
            elem.setAttribute( 'rel', 'sidebar' );
            elem.click();
        }
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.GetParam("cate");
    // *********************************************************************************************** //
    GetParam: function ( name )
    {
        /// <summary>인자에 해당하는 Query String 값을 가져옵니다.</summary>
        /// <param name="name" type="String">대상 Query String 이름</param>
        /// <returns type=""></returns>


        try
        {
            var results = new RegExp( '[\?&]' + name + '=([^&#]*)' ).exec( window.location.href );

            if ( results == null )
            {
                return "";
            }
            else
            {
                //return results[1] || 0;
                return results[1]; // || 0;
            }
        }
        catch ( e ) { return ""; }
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.GoTo("div1");
    // *********************************************************************************************** //
    GoTo: function ( name )
    {
        /// <summary>인자에 해당하는 id 값을 가진 element 로 Anchor 를 이동합니다.</summary>
        /// <param name="name" type="String">Anchor element's id</param>
        /// <returns type=""></returns>


        location.hash = name;
    }
    ,
    GotoPosition: function ( objclass ) {
        try {
            if (jQuery("." + objclass)) {

                var target_top = jQuery("." + objclass).offset().top;
                jQuery( 'html, body').stop().animate({ scrollTop: target_top }, 1000);

            }
        }
        catch (e) { }
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.LoadStyle(url)
    // 비동기 스타일 로드
    // *********************************************************************************************** //
    LoadStyle : function ( url ) {
                
        var head  = document.getElementsByTagName('head')[0];
        var link  = document.createElement('link');
        //link.id   = cssId;
        link.rel  = 'stylesheet';
        link.type = 'text/css';
        link.href = url;
        link.media = 'all';
        head.appendChild(link);
    }
    // *********************************************************************************************** //
    // CODE SNIPPET     : _common.LoadScript(url , callback)
    // 비동기 js 로드
    // *********************************************************************************************** //
    , LoadScript: function (url, callback) {

        var script = document.createElement("script")
        script.type = "text/javascript";

        if (script.readyState) {  //IE
            script.onreadystatechange = function () {
                if (script.readyState == "loaded" ||
                        script.readyState == "complete") {
                    script.onreadystatechange = null;
                    callback();
                }
            };
        } else {  //Others
            script.onload = function () {
                callback();
            };
        }

        script.src = url;
        document.getElementsByTagName("head")[0].appendChild(script);
    }

};


jQuery( document ).ready( function ( e ) {

    // Navigation 에 마우스 오버 시, 펼치기 ( 2D )
    jQuery( '#div2dCategory, #subDepth2d' ).bind( 'mouseover', function ( e ) {
        jQuery( '#subDepth2d' ).show();
    } );

    // Navigation 에 마우스 오버 시, 펼치기 ( 2D )
    jQuery('#div3dCategory, #subDepth3d').bind('mouseover', function (e) {
        jQuery( '#subDepth3d' ).show();
    } );

    // Navigation 에 마우스 아웃 시, 감추기 ( 3D  )
    jQuery('#div2dCategory, #subDepth2d').bind('mouseout', function (e) {
        jQuery( '#subDepth2d' ).hide();
    } );

    // Navigation 에 마우스 아웃 시, 감추기 ( 3D )
    jQuery('#div3dCategory, #subDepth3d').bind('mouseout', function (e) {
        jQuery('#subDepth3d').hide();
    });

    // Navigation 에 focus 시, 펼치기 ( 2D )
    jQuery('.j_btnShow2dCategory').bind('focus', function (e) {
        jQuery('#subDepth2d').show();
    });

    // Navigation 에 blur 시, 감추기 ( 2D )
    jQuery('.j_btnShow2dCategory').bind('blur', function (e) {
        if ($j('#subDepth2d').has(e.relatedTarget).length == 0) {
            jQuery('#subDepth2d').hide();
        }
    });

    // Navigation DIV 에 blur 시, 감추기 ( 2D )
    jQuery('#subDepth2d a').bind('blur', function (e) {
        if ($j('#subDepth2d').has(e.relatedTarget).length == 0) {
            jQuery('#subDepth2d').hide();
        }
    });

    // Navigation 에 focus 시, 펼치기 ( 3D )
    jQuery('.j_btnShow3dCategory').bind('focus', function (e) {
        jQuery('#subDepth3d').show();
    });

    // Navigation 에 blur 시, 감추기 ( 3D )
    jQuery('.j_btnShow3dCategory').bind('blur', function (e) {
        if ($j('#subDepth3d').has(e.relatedTarget).length == 0) {
            jQuery('#subDepth3d').hide();
        }
    });

    // Navigation DIV 에 blur 시, 감추기 ( 3D )
    jQuery('#subDepth3d a').bind('blur', function (e) {
        if ($j('#subDepth3d').has(e.relatedTarget).length == 0) {
            jQuery('#subDepth3d').hide();
        }
    });

    // 구형(Before 2016) Navigation 의 Select box 변경 시, 이동
    jQuery('.j_btnNavigation').bind('change', function (e) {

        var targetUrl = jQuery( this ).val();

        window.location.href = targetUrl;

    } );
} );

