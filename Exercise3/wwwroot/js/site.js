$(document).ready(function () {
  LoadTable();
});

function LoadTable() {
  let tbl = $("#tbl-employee tbody");
  tbl.empty();
  AjaxRequest("GET", "/api/employee", null, (response) => {
    for (let emp of response.data) {
      var row = `<tr>
                    <td>${emp.id}</td>
                    <td><a href='/Employee/Update/${emp.id}'>${emp.firstName} ${emp.lastName}</a></td>
                    <td>${emp.dateOfBirth}</td>
                    <td><button class="btn btn-sm btn-danger " onclick="DeleteEmployee(${emp.id})">Delete</button>
                    </td>
                </tr>`;
      tbl.append(row);
    }
  });
}

$("#btn-refresh").click(function (e) {
  LoadTable();
});

$("#btn-create").click(function (e) {
  var data = {
    FirstName: $("#create-fname").val(),
    LastName: $("#create-lname").val(),
    DateOfBirth: $("#create-dob").val(),
  };

  AjaxRequest("POST", "/api/employee", data, (response) => {
    alert(response.message);
    window.location.href = "/";
  });
});

$("#btn-update").click(function (e) {
  var data = {
    Id: $("#update-id").val(),
    FirstName: $("#update-fname").val(),
    LastName: $("#update-lname").val(),
    DateOfBirth: $("#update-dob").val(),
  };

  AjaxRequest("PUT", "/api/employee", data, (response) => {
    alert(response.message);
    window.location.href = "/";
  });
});

function DeleteEmployee(id) {
  AjaxRequest("DELETE", `/api/employee/${id}`, null, (response) => {
    alert(response.message);
    LoadTable();
  });
}

var AjaxRequest = async (
  method,
  url,
  data = null,
  callback,
  errorCallback = null
) => {
  let options = {
    type: method,
    url: url,
    contentType: "application/json",
    dataType: "json",
    success: (response) => {
      callback(response);
    },
  };

  if (data) {
    options.data = JSON.stringify(data);
  }
  $.ajaxSetup({
    timeout: 120000,
  });
  $.ajax(options).fail((response) => {
    ShowLoadingScreen(false);
    if (!errorCallback) {
      let errMessage = "An error occured.";
      if (response.responseJSON && response.responseJSON.message) {
        errMessage = response.responseJSON.message;
      } else {
        errMessage = response.statusText;
      }
      alert(errMessage);
    } else {
      errorCallback(response.responseJSON);
    }
  });
};
