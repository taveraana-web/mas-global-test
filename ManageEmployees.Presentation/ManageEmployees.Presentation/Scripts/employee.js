const $tbody = document.querySelector("#t-body");
const $id = document.querySelector("#id-input");
const $search = document.querySelector("#search-btn");
const $form = document.querySelector("#form");


const emptyResult = `<th colspan="7" style="text-align: center;">Employee Not Found </th>`;
const currency = Intl.NumberFormat();

function getRows(items) {
    const rows = items.map(function (item) {
        return `<tr>
                    <th>${item.Id}</th>
                    <td>${item.Name}</td>
                    <td>${item.RoleName}</td>
                    <td>$${currency.format(item.HourlySalary)}</td>
                    <td>$${currency.format(item.MonthlySalary)}</td>
                    <td>$${currency.format(item.AnnualSalary)}</td>
                 </tr>`;
    });
    return rows.join("");
}

function getEmployees(id) {
    const url = "http://localhost:55680/api/employee";
    const query = id ? `/${id}` : "";
    return fetch(`${url}${query}`).then(function (data) {
        return data.json();
    }).then(function (json) {
        if (json === null) {
            return [];
        }
        return Array.isArray(json) ? json : [json];
    });
}

function renderTable(id) {
    getEmployees(id).then(function (employees) {
        const htmlRows = getRows(employees);
        if (htmlRows !== "") {
            $tbody.innerHTML = htmlRows;
        } else {
            $tbody.innerHTML = emptyResult;
        }

    });
}

window.addEventListener("load", function () {
    renderTable();
});

$search.addEventListener("click", function () {
    renderTable($id.value);
});

$form.addEventListener("submit", function (event) {
    event.preventDefault();
    renderTable($id.value);
});
