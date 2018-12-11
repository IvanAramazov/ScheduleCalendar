# ScheduleCalendar

for dropdownlist:

<select id="txtEmployee" name="locality" style="background-size:inherit"></select>

            let dropdownEmployee = $('#txtEmployee');
            dropdownEmployee.empty();
            dropdownEmployee.append('<option selected="true" disabled> Choose Employee </option>');
            dropdownEmployee.prop('selectedIndex', 0);
            const url2 = '/Employees/GetEmployees';

            $.getJSON(url2, function (data) {
                $.each(data, function (key, entry) {
                    dropdownEmployee.append($('<option></option>').attr('value', entry.EmployeeId).text(entry.EmployeeName));
                })
            });
            
             function show_selected_employee() {
                var selector = document.getElementById('txtEmployee');
                var value = selector[selector.selectedIndex].value;

                selectedEmployeeId = value;
            }

            $('#txtEmployee').click(function () {
                show_selected_employee()
            })
