
function ContactSend()
{
    if ($("#name").val().trim() == "") {
        alert("請填寫姓名");
        return false;
    }
    if ($("#Phone").val().trim() == "") {
        if ($("#LocalPhone").val().trim() == "") {
            alert("電話或手機請選擇一樣填寫");
            return false;
        }

    }

    $.ajax({
        url: "/Liu/InsertContact",
        type: "POST",
        data: $("#ContactForm").serialize(),
        success: function (data) {
            if (data.Status == "0") {
                alert("\n訊息：送出成功，我們會盡快聯繫您！");

            } else {
                var message = data.StatusDesc;
                alert(message);
            }
        },
        error: function (err) {
            alert(err.Status);
        }
    });
}