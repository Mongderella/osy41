//------------------------사용법---------------------------------------------------------------------


//<script type="text/javascript" src="http://TOUR.THETRAVEL.CO.KR/global/js/jquery.js"></script>

// <script src="/Scripts/Views/Common/DateCounter.js"></script>
// <script>
//     //1.
//     SetDateElement("txtDay", "txtHour", "txtMin", "txtSec", false);
////2.
//setJuststartEndDay('01','08');
////3.
//DoDayCountByAjax();

//</script>



var timer;
var _second = 1000;
var _minute = _second * 60;
var _hour = _minute * 60;
var _day = _hour * 24;
var today;

var startDayEdit = '';
var endDayEdit = '';

var txtDay = "";
var txtHour = "";
var txtMin = "";
var txtSec = "";
var valOrTxt = true;

var startDate = "";
var endDate = "";


//이벤트에 사용될 엘리먼트들을 지정해준다, 년월일시분초 각각
//valueOrText은 value값에 넣게되는경우 true, text인 경우 false
function SetDateElement(hourEID, minEID, secEID, valueOrText) {
    txtHour = hourEID;
    txtMin = minEID;
    txtSec = secEID;
    valOrTxt = valueOrText;
}

//시작시간 및 종료시간 설정-------------------------------
function SetStartDate(year, month, day, hour, min, sec) {
    startDate = new Date(year, month, day, hour, min, sec);
}

function SetEndDate(year, month, day, hour, min, sec) {
    endDate = new Date(year, month, day, hour, min, sec);
}
//시작시간 및 종료시간 설정-------------------------------


//
function setJuststartEndDay(stDay, edDay) {
    startDayEdit = stDay;
    endDayEdit = edDay;
}
function SetByJustStartEndDay() {
    if (today == null || today == "")
    {
        console.log("초기 설정이 되어있지 않습니다.(today is null)");
        return;
    }
    else {
        var y = today.getFullYear();
        var m = today.getMonth();
        var d = today.getDate();
        if (Number(startDayEdit) >= Number(endDayEdit))//ex 1월 15일부터 2월 14일까지의 경우
        {
            if (Number(d) <= Number(endDayEdit)) {
                startDate = new Date(y, m-1, startDayEdit, 00, 00, 00);
                endDate = new Date(y, m, endDayEdit, 23, 59, 59);
            }
            else {
                startDate = new Date(y, m, startDayEdit, 00, 00, 00);
                endDate = new Date(y, m + 1, endDayEdit, 23, 59, 59);
            }
        }
        else {
            startDate = new Date(y, m, startDayEdit, 00, 00, 00);
            endDate = new Date(y, m, endDayEdit, 23, 59, 59);
        }
        
    }
    
}

function addZero(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}


function endTimeCounter() {

    if (valOrTxt) {
        //$j("#" + txtDay).val("0");
        jQuery("#" + txtHour).val("00");
        jQuery("#" + txtMin).val("00");
        jQuery("#" + txtSec).val("00");
    }
    else {
        //$j("#" + txtDay).text("0");
        jQuery("#" + txtHour).text("00");
        jQuery("#" + txtMin).text("00");
        jQuery("#" + txtSec).text("00");
    }
    if (timer != null)
        clearInterval(timer);
}

function setTodayBySetting(year, month, day, hour, min, sec) {

    today = new Date(year, month, day, hour, min, sec);

}

function DoDayCountByAjax() {
    //ajax
    var ajaxCountDate = new Date();
    var nowDate = ajaxCountDate;

    jQuery.ajax({
        url: "/event/web/201703_TimeSale/ServerTime.aspx",
        type: 'get',
        dataType: "json",
        success: function (data) {

            setTodayBySetting(data.year, data.month-1, data.day, data.hour, data.min, data.sec);
            if (startDayEdit != "" && endDayEdit != "")
                SetByJustStartEndDay();
            
            DoDayCount();
        },
        error : function(ex){
            console.log(ex);
            endTimeCounter();
    }
    });
    
    
}



function DoDayCount() {
    //성공 시 유효 검사 및 실행
    CheckVaildTime();
}


//초기설정에 대한 확인
function CheckVaildTime(countDate) {

    //Element Not Set
    //if (txtDay == "" || txtHour == "" || txtMin == "" || txtSec == "") {
    if (txtHour == "" || txtMin == "" || txtSec == "") {
        console.log("초기 설정이 되어있지 않습니다. (Element is Empty)");
        endTimeCounter();
        return;
    }


    //Start/EndDate not Loaded
    if (startDate == "" || endDate == "" || today == "")
    {
        console.log("초기 설정이 되어있지 않습니다. (Element is Empty)");
        endTimeCounter();
        return;
    }


    //Cannot Counting
    if (startDate < today && today < endDate) {
        timer = setInterval(remainTimeCounter, 1000);
    }
    else {
        endTimeCounter();
        return;
    }
}

//실제 카운팅 동작(Interval로 1초마다 실행됨)--------------------------------------
function remainTimeCounter() {
    var betweenTime = endDate - today;

    if (betweenTime < 0) {
        endTimeCounter();
        return;
    }
    else {
        //var days = Math.floor(betweenTime / _day);
        //var hours = Math.floor((betweenTime % _day) / _hour);
        var hours = Math.floor((betweenTime) / _hour);
        var minutes = Math.floor((betweenTime % _hour) / _minute);
        var seconds = Math.floor((betweenTime % _minute) / _second);
        if (valOrTxt)
        {
            //$j("#" + txtDay).val(days);
            jQuery("#" + txtHour).val(addZero(hours));
            jQuery("#" + txtMin).val(addZero(minutes));
            jQuery("#" + txtSec).val(addZero(seconds));
        }
        else
        {
            //$j("#" + txtDay).text(days);
            jQuery("#" + txtHour).text(addZero(hours));
            jQuery("#" + txtMin).text(addZero(minutes));
            jQuery("#" + txtSec).text(addZero(seconds));
        }


        today.setSeconds(today.getSeconds() + 1);
    }
}