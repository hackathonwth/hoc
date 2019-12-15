var txt_minlength = 1;
var num_minlength = 1;
var day_minlength = 1;
var month_minlength = 1;
var year_minlength = 4;
var hour_minlength = 1;
var min_minlength = 1;

function trim(txt_val) {
    return rtrim(ltrim(txt_val));
}

//LTrim
function ltrim(txt_val) {
    var bflag = false;
    var ntxt_val = "";
    var k = 0;
    if (txt_val.length === 0) return ntxt_val;
    for (k = 0; k < txt_val.length; k++) {
        if (txt_val.charAt(k) !== ' ') break;
    }
    //if txt_val lenght is 1 and if it is ok
    if (txt_val.length === 1) k = 0;
    for (; k < txt_val.length; k++) {
        ntxt_val = ntxt_val + txt_val.charAt(k);
    }
    //alert("ltrim="+ntxt_val);
    return ntxt_val;
}
//RTrim 
function rtrim(txt_val) {
    var bflag = false;
    var ntxt_val = "";
    var k = 0;
    if (txt_val.length === 0) return ntxt_val;
    for (k = txt_val.length - 1; k > -1; k--) {
        if (txt_val.charAt(k) !== ' ') break;
    }
    if (txt_val.length === 1) k = txt_val.length;
    for (p = 0; p < (k + 1) ; p++) {
        ntxt_val = ntxt_val + txt_val.charAt(p);
    }
    //alert("Rtrim="+ntxt_val);
    return ntxt_val;
}

//date validation
function isUSDate(txt_month, txt_day, txt_year) {
    var d = txt_day;
    var m = txt_month;
    var y = txt_year;
    if (d === 0 || m === 0 || y === 0)
        return false;
    if (m > 12) return false;
    if (m === 1 || m === 3 || m === 5 || m === 7 || m === 8 || m === 10 || m === 12)
        var dmax = 31;
    else
        if (m === 4 || m === 6 || m === 9 || m === 11) dmax = 30;
        else
            if ((y % 400 === 0) || (y % 4 === 0 && y % 100 !== 0)) dmax = 29;
            else dmax = 28;

    if (d > dmax) return false;
    if (y < 1900) return false; //can't be that old
    if (y > 9999) return false;
    return true;
}

//date validation
function isDateStr(txt_date) {

    var arr = new Array(3);

    arr = txt_date.split("/");

    if (!isNumber(arr[0]) || !isNumber(arr[1]) || !isNumber(arr[2]))
        return false;
    else
        return (isUSDate(arr[0], arr[1], arr[2]));
}

//check if text has only alpha numerics
function isChar(txt_val) {
    if (isEmpty(txt_val, txt_minlength)) return (false);
    return (true);
}

//Check if value is empty
function isEmpty(txt_val, minlength) {
    txt_val = trim(txt_val);
    if (txt_val.length < minlength) return (true);
    return (false);
}
//Check if value is special char
function isSpecialChar(txt_val) {
    var ArrSpecChars = new Array("€", "Ã", "ƒ", "Ä", "„", "Å", "…", "Æ", "†", "Ç", "‡", "È", "ˆ", "É", "‰", "Ê", "Š", "Ë", "‹", "Ì", "Œ", "Í", "Ž", "Î", "‘", "Ï", "’", "Ð", "Ñ", "Ò", "•", "Ó", "–", "Ô", "—", "Õ", "˜", "Ö", "™", "×", "š", "Ø", "›", "Ù", "œ", "Ú", "ž", "Û", "Ÿ", "Ü", "¡", "Þ", "¢", "ß", "£", "à", "¤", "á", "¥", "â", "¦", "ã", "§", "ä", "¨", "å", "©", "æ", "ª", "ç", "«", "è", "¬", "é", "­", "ê", "®", "ë", "¯", "ì", "°", "í", "±", "î", "²", "ï", "³", "´", "ñ", "µ", "ò", "¶", "ó", "•", "ô", "¸", "õ", "¹", "ö", "º", "÷", "»", "¼", "½", "¾", "¿", "ü", "À", "ý", "Á", "þ", "Â", "ÿ");
    var i;
    var result = false;
    txt_val = trim(txt_val);
    for (i in ArrSpecChars) {
        if (txt_val.match(ArrSpecChars[i])) {
            result = true;
            break;
        }
    }
    return (result);
}
//Get the special char
function GetSpecialChar(txt_val) {
    var ArrSpecChars = new Array("€", "Ã", "ƒ", "Ä", "„", "Å", "…", "Æ", "†", "Ç", "‡", "È", "ˆ", "É", "‰", "Ê", "Š", "Ë", "‹", "Ì", "Œ", "Í", "Ž", "Î", "‘", "Ï", "’", "Ð", "Ñ", "Ò", "•", "Ó", "–", "Ô", "—", "Õ", "˜", "Ö", "™", "×", "š", "Ø", "›", "Ù", "œ", "Ú", "ž", "Û", "Ÿ", "Ü", "¡", "Þ", "¢", "ß", "£", "à", "¤", "á", "¥", "â", "¦", "ã", "§", "ä", "¨", "å", "©", "æ", "ª", "ç", "«", "è", "¬", "é", "­", "ê", "®", "ë", "¯", "ì", "°", "í", "±", "î", "²", "ï", "³", "´", "ñ", "µ", "ò", "¶", "ó", "•", "ô", "¸", "õ", "¹", "ö", "º", "÷", "»", "¼", "½", "¾", "¿", "ü", "À", "ý", "Á", "þ", "Â", "ÿ");
    var i;
    var result = "";
    txt_val = trim(txt_val);
    for (i in ArrSpecChars) {
        if (txt_val.match(ArrSpecChars[i])) {
            result = ArrSpecChars[i];
            break;
        }
    }
    return (result);
}
//check if text contains only numerics
function isNumber(txt_val) {
    var k = 0;
    if (isEmpty(txt_val, num_minlength)) return false;
    for (k = 0; k < txt_val.length; k++) {
        if (isNaN(txt_val.charAt(k))) return false;
    }
    return true;
}

//check if text is number or decimal
function isDecimal(txt_val) {
    var k = 0;
    var d = 0;
    if (isEmpty(txt_val, num_minlength)) return false;
    for (k = 0; k < txt_val.length; k++) {
        if (isNaN(txt_val.charAt(k))) {
            if (txt_val.charAt(k) === '.') {
                d++;
                if (d > 1) return false;
            }
            else {
                return false;
            }
        }
    }
    return true;
}

function NumberOfDays(month, year) {
    var n = 0;
    if (month >= 1 && month <= 12) {
        if (month == 2) {
            if (IsLeapYear(year))
                n = 29;
            else
                n = 28;
        }
        else if (month === 1 || month === 3 || month === 5 || month === 7 || month === 8 || month === 10 || month === 12)
            n = 31
        else
            n = 30;
    }

    return (n);
}

function IsLeapYear(year) {
    var r = year % 4;
    if (r === 0)
        return (true);
    else
        return (false);
}

function isValidateEmail(email) {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (reg.test(email) === false) {
        return false;
    }
    return true;

}

function isValidPhoneNumber(phone) {
    var reg = /^[+1]?|(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$/;
    if (reg.test(phone) === false)
        return false;
    return true;
}

