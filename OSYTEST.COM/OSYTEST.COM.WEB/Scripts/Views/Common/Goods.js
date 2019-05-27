/* 
 * *********************************************************************************************** //
 * MODIFIED DATE    : 2016-02-17 ( CREATED - 자유 여행 개편 )
 * MODIFIER         : DAN LEE
 * DESCRIPTION      : 상품 리스트 관련  
 *                    
 * *********************************************************************************************** //
*/

/* INITIALIZE - Objective Functions */
var _globalGoods =
{
    // 선택된 날짜 ( 출발일 선택 레이어에서 사용되는 변수 )
    SELCETED_DATE : '',

    GetGoodsList: function (cate, page, pageSize, keyword, sortType, viewType, setViewType, replaceTargetDivId, startDT, nightCount, totalCountDivId) {
        
        /// <summary>[ Free/D3 ] 인자에 해당하는 상품 리스트( 리스트형 및 이미지형 ) 를 Partial HTML 형태로 가져옵니다.</summary>
        /// <param name="cateCD" type="String">카테고리 코드</param>
        
        /// <param name="page" type="String">표시할 페이지</param>
        /// <param name="pageSize" type="String">페이지에 표시할 개체 수</param>
        /// <param name="keyword" type="String">검색 키워드</param>
        /// <param name="sortType" type="String">A : 추천 상품순 / B : 인기 상품순 / C : 낮은 가격순 / D : 높은 가격순</param>
        /// <param name="viewType" type="String">list : 리스트형 / image : 이미지형</param>
        /// <param name="setViewType" type="String">L : 리스트형 / 2 : 이미지형 2 EA / 3 : 이미지형 3 EA /</param>
        /// <param name="replaceTargetDivId" type="String">조회된 html 을 할당할 div 개체 id</param>
        /// <param name="startDT" type="String">출발일 선택 일자</param>
        /// <param name="nightCount" type="String">여행 기간 ( 1 ~ 10 : [1박 이하 ~ 10박 이상] )</param>
        /// <param name="totalCountDivId" type="String">검색 건 개수를 표시할 div 개체 id ( opt. )</param>
        /// <returns type=""></returns>

        var route = "";

        if (location.href.indexOf("/free/") >= 0)
        {
            route = "free";
        }
        else if (location.href.indexOf("/jeju/") >= 0)
        {
            route = "jeju";
        }
        else if (location.href.indexOf("/package/") >= 0)
        {
            route = "package";
        }

        var route = "";

        if (location.href.indexOf("/free/") >= 0)
        {
            route = "free";
        }
        else if (location.href.indexOf("/jeju/") >= 0)
        {
            route = "jeju";
        }
        else if (location.href.indexOf("/package/") >= 0)
        {
            route = "package";
        }

        _common.AttachLoadingImage('sortDiv', 'imgLoading_GoodsList');

        jQuery.ajax( {

            type: 'GET',
            url: '/' + route + '/GetGoodsList/?cate=' + cate + '&page=' + page + '&pageSize=' + pageSize + '&keyword=' + encodeURIComponent(keyword)
                + '&sortType=' + sortType + '&viewType=' + viewType + '&setViewType=' + setViewType + '&startDT=' + startDT + '&nightCount=' + nightCount ,
            data: '',
            success: function ( result ) {

                //jQuery( '#' + replaceTargetDivId ).hide();
                //jQuery( '#' + replaceTargetDivId ).html( result ).fadeIn( 300 );
                //////jQuery( '#' + replaceTargetDivId ).animate( { opacity: 0.8, background-color: #000 }, 500, function () { jQuery( '#' + replaceTargetDivId ).html( result ); });
                //////jQuery( '#' + replaceTargetDivId ).animate( { opacity: 1 }, 500  );
                
                jQuery( '#' + replaceTargetDivId ).html( result );

                //_common.HideLayerWithBackground();
                //_common.HideLoadingImage();

                //jQuery( 'imgLoading_GoodsList' ).stop();
                _common.DetachLoadingImage( 'imgLoading_GoodsList' );

                // 검색 건 개수를 표시할 div id 
                if ( totalCountDivId != '' )
                {
                    if ( jQuery( '#' + totalCountDivId ).length > 0 ) {

                        // Goods List Div 내부에 기재된 정보를 가져옴
                        jQuery( '#' + totalCountDivId ).text(jQuery('#tbTotalCount_Partial').val());
                    }
                }

                jQuery("[name='goodsCDChk_list']").on('click', function (e) {

                    var len = jQuery("input[name='goodsCDChk_list']:checked").length;

                    if (len <= 3) {
                        if ($j(this).is(':checked')) {
                            $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', 'inline-block');
                            $j(this).parent().find('#chk_CompareLabel_' + $j(this).attr('data-index'))[0].innerHTML = '';
                        } else {
                            $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', 'none');
                            $j(this).parent().find('#chk_CompareLabel_' + $j(this).attr('data-index'))[0].innerHTML = '상품비교';
                        }
                    }
                })
            },
            error: function ( result ) {

                jQuery( '#' + replaceTargetDivId ).html( '<span>상품 목록 가져오기 실패</span>' );

                _common.DetachLoadingImage( 'imgLoading_GoodsList' );


                //_common.HideLayerWithBackground();
                //_common.HideLoadingImage();

                //alert( result.responseText );
                //alert( result.status );
            },
            complete: function (data) {
                if (typeof (facebook_SearchV2) == 'function') {
                    facebook_SearchV2();
                }
            }
        } );
    }
    , GetGoodsList_v9: function (cate, currentPage, pageSize, keyword, sortType, viewType, setViewType, replaceTargetDivId, startDT, totalCountDivId, day, searchOption, daycntfrom, daycntto) {
        
        /// <param name="cate">카테고리 코드</param>
        /// <param name="currentPage">현재페이지</param>
        /// <param name="pageSize">페이지 사이즈</param>
        /// <param name="keyword">키워드</param>
        /// <param name="sortType">A : 추천 상품순 / B : 인기 상품순 / C : 낮은 가격순 / D : 높은 가격순</param>
        /// <param name="viewType">list : 리스트형 / image : 이미지형</param>
        /// <param name="setViewType">L : 리스트형 / 2 : 이미지형 2 EA / 3 : 이미지형 3 EA /</param>
        /// <param name="replaceTargetDivId"> 리스트 바디아이디
        /// <param name="startDT" >출발일 선택 일자</param>
        /// <param name="totalCountDivId" type="String">검색 건 개수를 표시할 div 개체 id ( opt. )</param>
        /// <param name="day">day</param> 요일
        /// <param name="searchOption">searchOption</param> 검색 타입 01,02 지역테마 , 03 일별 , 04 요일별
        /// <param name="daycntfrom">daycntfrom</param> 일별 검색 에서 시작 숙박일
        /// <param name="daycntto">daycntto</param> 일별 검색 에서 종류 숙박일 

        _common.AttachLoadingImage('sortDiv', 'imgLoading_GoodsList');

        jQuery.ajax({

            type: 'GET',
            url: '/Package/GetGoodsList_v9/?cate=' + cate
                + '&page=' + currentPage
                + '&pageSize=' + pageSize
                + '&keyword=' + encodeURIComponent(keyword)
                + '&sortType=' + sortType
                + '&viewType=' + viewType
                + '&setViewType=' + setViewType
                + '&startDT=' + startDT
                + '&searchOption=' + searchOption
                + '&day=' + day
                + '&daycntfrom=' + daycntfrom
                + '&daycntto=' + daycntto
            ,

            data: '',
            success: function (result) {

                jQuery('#' + replaceTargetDivId).html(result);

                _common.DetachLoadingImage('imgLoading_GoodsList');

                // 검색 건 개수를 표시할 div id 
                if (totalCountDivId != '') {
                    if (jQuery('#' + totalCountDivId).length > 0) {

                        // Goods List Div 내부에 기재된 정보를 가져옴
                        jQuery('#' + totalCountDivId).text(jQuery('#tbTotalCount_Partial').val());
                    }
                }

                jQuery("[name='goodsCDChk_list']").on('click', function (e) {

                    var len = jQuery("input[name='goodsCDChk_list']:checked").length;

                    if (len <= 3) {
                        if ($j(this).is(':checked')) {
                            $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', 'inline-block');
                            $j(this).parent().find('#chk_CompareLabel_' + $j(this).attr('data-index'))[0].innerHTML = '';
                        } else {
                            $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', 'none');
                            $j(this).parent().find('#chk_CompareLabel_' + $j(this).attr('data-index'))[0].innerHTML = '상품비교';
                        }
                    }
                })
            },
            error: function (result) {

                jQuery('#' + replaceTargetDivId).html('<span>상품 목록 가져오기 실패</span>');

                _common.DetachLoadingImage('imgLoading_GoodsList');

            },
            complete: function (data) {
                if (typeof (facebook_SearchV2) == 'function') {
                    facebook_SearchV2()
                }
            }
        });
    }
    ,
    RefreshHighlightOfViewTypeButton: function ( obj ) {
        /// <summary>[ Free/D3 ] 이미지형 / 리스트형 버튼의 하이라이트를 설정합니다.</summary>
        /// <returns type=""></returns>


        jQuery.each( jQuery( '.j_btnViewType' ), function ( idx, item ) {

            if ( jQuery( item ).attr( 'id' ) == jQuery( obj ).attr( 'id' ) ){
                if( jQuery( item ).hasClass( 'on' ) == false )
                    jQuery( item ).addClass( 'on' );
            }
            else {
                if ( jQuery( item ).hasClass( 'on' ) )
                    jQuery( item ).removeClass( 'on' );
            }

        } );
    }
    ,
    RefreshHighlightOfSortTypeButton: function ( obj ) {
        /// <summary>[ Free/D3.cshtml ] 정렬 버튼의 하이라이트를 설정합니다.</summary>
        /// <returns type=""></returns>


        jQuery.each( jQuery( '.j_btnSortType' ), function ( idx, item ) {

            if ( jQuery( item ).attr( 'id' ) == jQuery( obj ).attr( 'id' ) ){
                if(jQuery( item ).hasClass( 'on' ) == false )
                    jQuery( item ).addClass( 'on' );
            }
            else {
                if ( jQuery( item ).hasClass( 'on' ) )
                    jQuery( item ).removeClass( 'on' );
            }

        } );
    }
    ,
    RefreshHighlightOfD4Button: function ( obj ) {
        /// <summary>[ Free/D3 ] 4 Depth 버튼의 하이라이트를 설정합니다.</summary>
        /// <returns type=""></returns>


        jQuery.each( jQuery( '.j_btnD4Category' ), function ( idx, item ) {

            if ( jQuery( item ).attr( 'id' ) == jQuery( obj ).attr( 'id' ) ) {
                if ( jQuery( item ).hasClass( 'on' ) == false )
                    jQuery( item ).addClass( 'on' );
            }
            else {
                if ( jQuery( item ).hasClass( 'on' ) )
                    jQuery( item ).removeClass( 'on' );
            }

        } );
    }
    ,
    GetGoodsSelectCondition_SortType: function () {
        /// <summary>[ Free/D3 ] 현재 설정된 상품 정렬 타입을 가져옵니다.</summary>
        /// <returns type="string">정렬 타입 ( 'A' : 추천 상품순 / 'B' : 인기 상품순 / 'C' : 낮은 가격순 / 'D' : 높은 가격순 )</returns>


        var returnValue = 'B';

        jQuery.each( jQuery( '.j_btnSortType' ), function ( idx, item ) {

            if ( jQuery( item ).hasClass('on' ))
                returnValue = jQuery( item ).attr('data-sorttype');
        } );

        return returnValue;
    }
    ,
    GetGoodsSelectCondition_PageSize: function () {
        /// <summary>[ Free/D3 ] 현재 설정된 Page Size 를 가져옵니다.</summary>
        /// <returns type="int">Page Size ( 12 또는 24)</returns>


        var returnValue = 12;
        returnValue = jQuery( '#cbPageSize' ).val();

        return returnValue;
    }
    ,
    GetGoodsSelectCondition_ViewType: function () {
        /// <summary>[ Free/D3 ] 현재 설정된 View Type 를 가져옵니다.</summary>
        /// <returns type="string">상품 표시 타입 ( 'list' : 리스트형 / 'iamge' : 이미지형 )</returns>


        var returnValue = 'list';
        
        jQuery.each( jQuery( '.j_btnViewType' ), function ( idx, item ) {

            if ( jQuery( item ).hasClass( 'on' ) )
                returnValue = jQuery( item ).attr( 'data-viewtype' );

        } );

        return returnValue;
    }
    ,
    ValidationCompareGoodsCount: function ( obj ) {
        /// <summary>[ Free/D3 ] 상품 비교 Chkeckbox 가 선택될 때마다 개수를 검증합니다. ( 최대 3개 선택 가능 )</summary>
        /// <returns type=""></returns>

        var len = jQuery( "input[name='goodsCDChk_list']:checked" ).length;

        if ( len > 3 ) {

            // 마지막 선택 Checkbox 해제
            jQuery( obj ).prop( 'checked', false );

            alert( '상품 최대 비교 개수는 3개 입니다.' );
        }
    }
    ,
    ShowLayer_CompareGoods: function ( targetDivId ) {
        /// <summary>[ Free/D3 ] 상품 비교 Chkeckbox 가 선택된 항목을 비교하는 레이어를 표시합니다. ( 최대 3개 선택 가능 )</summary>
        /// <param name="targetDivId" type="String">상품 비교 결과 HTML 이 할당될 Div Element id</param>
        /// <returns type=""></returns>


        var len = jQuery( "input[name='goodsCDChk_list']:checked" ).length;

        // Checked 상태 개수 확인
        if ( len <= 1 ) {
            alert( "상품비교는 최소 2개의 상품을 선택하셔야 합니다." );
            return;
        }

        if ( len >= 4 ) {
            alert( "상품비교는 최대 3개의 상품까지 가능 합니다." );
            return;
        }

        _common.ShowLoadingImage();

        // Checked 상태의 상품 정보 변수에 할당
        var arrayBaseGoodsCD = [];

        jQuery.each( jQuery( "input[name='goodsCDChk_list']:checked" ), function ( idx, item ) {
            arrayBaseGoodsCD.push( jQuery( item ).attr( 'data-basegoodscd' ) );
        } );

        var target_1 = typeof arrayBaseGoodsCD[0] != 'undefined' ? arrayBaseGoodsCD[0] : '';
        var target_2 = typeof arrayBaseGoodsCD[1] != 'undefined' ? arrayBaseGoodsCD[1] : '';
        var target_3 = typeof arrayBaseGoodsCD[2] != 'undefined' ? arrayBaseGoodsCD[2] : '';

        jQuery.ajax( {

            type: 'GET',
            url: '/goods/_InnerCompareGoods?baseGoods1=' + target_1 + '&baseGoods2=' + target_2 + '&baseGoods3=' + target_3,
            data: '',
            success: function ( result ) {

                jQuery('#' + targetDivId).html(result);
                // Layer 표시 function 파라미터 변경  targetDivId + '|' + Focus Return받을 object ID
                _common.ShowCenterPopupLayer_fix(targetDivId + '|' + 'btnCompareGoods');

            },
            error: function ( result ) {

                alert( "상품 정보 가져오기 실패" );

                //alert( result.responseText );
                //alert( result.status );
            },
            complete: function ( data ) {
                _common.HideLoadingImage();
            }
        } );
    }
    ,
    ShowLayer_GoodsListByDeparture: function (baseGoodsCD, supplierCD, cateCD, targetDivId, focusId) {
        /// <summary>[ Free/D3 ] 출발일 보기 버튼을 눌러 출발일 기준의 상품 리스트 레이어를 표시합니다.</summary>
        /// <param name="baseGoodsCD" type="String">출발일 보기 레이어에 바인드 할 기초 상품 코드</param>
        /// <param name="targetDivId" type="String">출발일 보기 HTML 이 할당될 Div Element id</param>
        /// <param name="focusId" type="String">팝업 닫을 때 focus return 해 줄 Element id</param>
        /// <returns type=""></returns>


        _common.ShowLoadingImage();

        jQuery.ajax( {

            type: 'GET',
            url: '/goods/_InnerGoodsListByDepartureWithCalendar?baseGoodsCD=' + baseGoodsCD + '&supplierCD=' + supplierCD + "&cateCD=" + cateCD,
            data: '',
            success: function ( result ) {

                jQuery( '#' + targetDivId ).html( result );
                _common.ShowCenterPopupLayer_fix( targetDivId + '|' + focusId );

            },
            error: function ( result ) {

                alert( "출발일 보기 팝업 표시에 실패하였습니다." );

                //jQuery( '#' + targetDivId ).html( '<span>상품 정보 가져오기 실패</span>' );
                //_common.ShowCenterPopupLayer_fix( targetDivId );

                //alert( result.responseText );
                //alert( result.status );
            },
            complete: function ( data ) {
                _common.HideLoadingImage();
            }
        } );

    }
    ,
    RebindCalendarWithBaseGoods: function ( baseGoodsCD, startDT, monthCount, targetDivId, eventTrigerClassName, callbackArg, callback ) {
        /// <summary>[ Free/D3 ] 기초상품 코드 기반으로 출발 상품 정보가 바인드 된, 달력 HTML 을 가져옵니다.</summary>
        /// <param name="baseGoodsCD" type="String">달력에 바인드 할 기초 상품 코드</param>
        /// <param name="startDT" type="String">yyyyMMdd 형태의 달력 표시 시작 일자</param>
        /// <param name="monthCount" type="String">표시할 달력 개수</param>
        /// <param name="targetDivId" type="String">달력이 표시될 Div</param>
        /// <param name="eventTrigerClassName" type="String">활성화 된 달력 일자에 Jquery Event 할당을 위해 부여하는 Class Name</param>
        /// <param name="callbackArg" type="String">CallBack 함수에 사용되는 Argument</param>
        /// <param name="callback" type="String">달력이 바인드 되고 난 후, 동작할 Callback Function</param>
        /// <returns type=""></returns>

        var _path = location.href
        var seq = "";
        if (typeof (getParameterByName) == "function") {
            try {
                seq = getParameterByName("seq", _path);
            }
            catch (e) { }
        }

        var ajaxUrl = '/sharedcontrol/GetCalendarMulti?baseGoodsCD=' + baseGoodsCD + '&startDT=' + startDT + '&monthCount=' + monthCount + '&targetDivId=' + targetDivId + '&eventTrigerClassName=' + eventTrigerClassName;
        ajaxUrl += !!seq ? "&seq=" + seq : "";

        jQuery.ajax( {

            type: 'GET',

            url: ajaxUrl,
            data: '',
            success: function ( result ) {

                jQuery( '#' + targetDivId ).html( result );

                // Callback ( ex: show layer ) 이 설정되어 있을 경우 실행
                if(typeof callback == 'function')
                    callback( callbackArg );
            },
            error: function ( result ) {

                alert( "달력 생성 실패" );

                //alert( result.responseText );
                //alert( result.status );
            },
            complete: function ( data ) {
            }
        } );
    }
    ,
    ShowOtherMonthsPopUp: function (divId){
        /// <summary>1개 달력에서 yyyy.MM 을 클릭 시, 이후 3개월치로 이동 가능한 팝업 표시</summary>
        /// <param name="divId" type="String">이후 3달치 링크 팝업</param>
        /// <returns type=""></returns>
        
        
        jQuery( '#' + divId ).toggle();
    }
}

jQuery( document ).ready( function ( e ) {

    // 상품 표시 타입 버튼 하이라이트 갱신 ( 이미지형 / 리스트형 )
    jQuery( '.j_btnViewType' ).on( 'click', function ( e ) {
        _globalGoods.RefreshHighlightOfViewTypeButton( this );
    } );

    // 상품 정렬 버튼 하이라이트 갱신 ( 추천 상품순 / 인기 상품순 / 낮은 가격순 / 높은 가격 )
    jQuery( '.j_btnSortType' ).on( 'click', function ( e ) {
        _globalGoods.RefreshHighlightOfSortTypeButton( this );
    } );

    // D3 View 에서 4 Depth 메뉴를 클릭할 때 버튼 하이라이트 갱신
    jQuery( '.j_btnD4Category' ).on( 'click', function ( e ) {
        _globalGoods.RefreshHighlightOfD4Button( this );
    } );

    // 상품 비교 Checkbox 가 클릭 될 때, 선택 개수 검증
    jQuery( document.body ).on( 'keyup click', '.j_chkCompare', function ( e ) {
        _globalGoods.ValidationCompareGoodsCount( this );
    } );

    // 상품 비교 버튼을 눌렀을 때, 비교하기 레이어 표시
    jQuery('.j_btnCompareGoods').on('keyup click', function (e) {
        _globalGoods.ShowLayer_CompareGoods('compareViewer');
    });

    jQuery("[name='goodsCDChk_list']").on('click', function (e) {

        var len = jQuery( "input[name='goodsCDChk_list']:checked" ).length;

        if (len <= 3) {
            if ($j(this).is(':checked')) {
                $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', 'inline-block');
                $j(this).parent().find('#chk_CompareLabel_' + $j(this).attr('data-index'))[0].innerHTML = '';
            } else {
                $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', 'none');
                $j(this).parent().find('#chk_CompareLabel_' + $j(this).attr('data-index'))[0].innerHTML = '상품비교';
            }
        }
    })

    function goodsCDChk_clickEvent(e) {
        var len = jQuery("input[name='goodsCDChk_list']:checked").length;

        if (len <= 3) {
            if ($j(this).is(':checked')) {
                $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', '');
                $j(this).parent().find('label').css('display', 'none');;
            } else {
                $j('#anchor_Compare_' + $j(this).attr('data-index')).css('display', 'none');
                $j(this).parent().find('label').css('display', '');;
            }
        }
    }

    // 상품 비교 팝업 - 닫기 버튼 클릭
    jQuery( document.body ).on( 'click', '#btnCloseComparePopup', function ( e ) {
        _common.HideLayerWithBackground( 'compareViewer' );
    } );

    // 상품 비교 팝업 - 상품 자세히 보기
    jQuery( document.body ).on( 'click', '.j_btnGoBaseGoodsDetail', function ( e ) {
        location.href = jQuery( this ).attr( 'data-targeturl' );
    } );

    // 출발일 선택 팝업 - 출발일 보기
    jQuery( document.body ).on( 'click', '.j_btnGoodsListByDepareure', function ( e ) {
        var baseGoodsCD = jQuery( this ).attr( 'data-basegoodscd' );
        var supplierCD = jQuery( this ).attr( 'data-suppliercd' );
        var cateCD = jQuery( this ).attr( 'data-catecd' );
        var targetPopupDivId = 'divDepartureGoods';
        // 팝업 닫을 때 focus return 해 줄 Element ID 파라미터 focusId 추가, id가 없을 경우 공백
        var focusId = ($j(this).attr('id') == undefined) ? '' : $j(this).attr('id');

        // 팝업 닫을 때 focus return 해 줄 Element ID 파라미터 focusId 추가
        _globalGoods.ShowLayer_GoodsListByDeparture(baseGoodsCD, supplierCD, cateCD, targetPopupDivId, focusId);
    } );

    // 달력 컨트롤 재바인드 - [ 이전, 다음, 3개월치 팝업 리스트 ] 버튼 클릭 시 달력 갱신
    jQuery( document.body ).on( 'click', '.j_btnCalendar', function ( e ) {
        var baseGoodsCD = jQuery( this ).attr( 'data-basegoodscd' );
        var startDT = jQuery( this ).attr( 'data-startdt' );
        var monthCount = jQuery( this ).attr( 'data-monthcount' );
        var targetCalendarDivId = jQuery( this ).attr( 'data-targetdivid' );
        var eventTriggerClassName = jQuery( this ).attr( 'data-eventtriggername' );

        // 상세 페이지일 경우 출발 상품 리스트 재바인딩
        if(location.href.toLocaleLowerCase().indexOf('/goods/detail') > -1)
            _globalGoods.RebindCalendarWithBaseGoods( baseGoodsCD, startDT, monthCount, targetCalendarDivId, eventTriggerClassName, null, RefreshGoodsListAfterRebindCalendar4Detail );
        else
            _globalGoods.RebindCalendarWithBaseGoods( baseGoodsCD, startDT, monthCount, targetCalendarDivId, eventTriggerClassName );
    } );

    // 상품 비교 팝업 - 닫기 버튼 클릭
    jQuery( document.body ).on( 'click', '#btnCloseGoodsListByDeparture', function ( e ) {
        _common.HideLayerWithBackground( 'divDepartureGoods' );
    } );

    // 1개 달력에서 yyyy.MM 을 클릭 시, 이후 3개월치로 이동 가능한 팝업 표시
    jQuery( document.body ).on( 'click', '.j_btnShowOtherMonths', function ( e ) {
        
        var targetDivId = jQuery( this ).attr( 'data-targetdivid' );

        _globalGoods.ShowOtherMonthsPopUp( targetDivId );

    } );

    // 출발일 선택 레이어에서 상품 리스트 선택 시, 상세 페이지로 이동
    jQuery( document.body ).on( 'click', '.j_btnGoodsDetail', function ( e ) {

        var targetUrl= jQuery( this ).attr( 'data-url' );

        location.href = targetUrl;

    } );
} );