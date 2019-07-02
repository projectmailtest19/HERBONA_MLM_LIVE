var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";
var _allowadd, _allowedit, _allowdelete;
$(document).ready(function () {


    //// *******************************start permissionm**************************
    //permissionforlist('ContactList.aspx', 'AddContact.aspx', 'btn_create');
    //// *******************************end permissionm**************************

    setTimeout(function () {
        GetDashboardDetails();
    }, 0);
    $("#Heading").text('Welcome back, ' + localStorage.getItem('CONTACT_NAME'));
});
function GetDashboardDetails()
{
    Req = 'DashboardDetails';
    obj = "DashboardDetails";
    url = "Home.aspx/DashboardDetails";
    ht = {};
    LoadAjaxDashboardDetails(ht, obj, Req, url);
}
function LoadAjaxDashboardDetails(ht, obj, Req, url) {
    $('body').pleaseWait();

    $.ajax({
        type: "POST",
        url: url,
        data: "{ht:" + JSON.stringify(ht) + ",Type :'" + obj + "' ,Req :'" + Req + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Result) {
            var json = jQuery.parseJSON(Result.d.ErrorDetail);
            var sa_error = "";
            var sa_errrorMsg = "";
            $.each(json, function (index, K) {
                sa_error = K.Error;
                sa_errrorMsg = K.ErrorMessage;
            });
            if (sa_error != 'false') {
                swal("", sa_errrorMsg, "error");
                $('body').pleaseWait('stop');
                return 0;
            }

            if (obj == "DashboardDetails") {
                if (Result.d.DashboardDetails != "" && Result.d.DashboardDetails != undefined) {
                    var json = jQuery.parseJSON(Result.d.DashboardDetails);

                    $.each(json, function (index, item) {
                        $("#h_Personal_Purchase_Invoice").text(item.personal_purchase_invoice);
                        $("#h_repurchase_due_date").text(item.next_due_date_repurchase);
                        $("#h_Payschedule_purchase").text(item.current_payschedule_purchase);
                        $("#Span_TotalFtb").text(item.total_ftb);
                        $("#Span_TotalTLB").text(item.total_tlb);
                        $("#Span_TotalDplx").text(item.total_dplx);
                        $("#Span_TotalRab").text(item.total_rab);
                        $("#Span_CarTravelFund").text(item.car_travel_fund);
                        $("#Span_HouseFund").text(item.house_fund);
                        $("#Span_LeadershipBonus").text(item.leadership_bonus);
                        $("#Span_RankingBonus").text(item.elite_ranking_bonus);
                        $("#Span_RetailProfit").text(item.retail_profit);
                        $("#Span_RankTitle").text(item.current_rank_tittle);
                        $("#Span_DirectorsNumber").text(item.no_of_directs);
                    });
                }
            }
            $('body').pleaseWait('stop');
        }
    });
}



