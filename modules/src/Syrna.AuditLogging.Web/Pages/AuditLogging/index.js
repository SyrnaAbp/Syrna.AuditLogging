﻿(function ($) {
    var l = abp.localization.getResource('SyrnaAuditLogging');

    var _auditLoggingAppService = syrna.auditLogging.auditLog;

    var _detailModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'AuditLogging/DetailModal'
    });

    var _dataTable = null;

    $(function () {
        var _$wrapper = $('#AuditLogsWrapper');
        var _$table = _$wrapper.find('table');
        var _$searchBth = _$wrapper.find('#search');
        var _$resetBth = _$wrapper.find('#reset');
        var $dateRangePicker = _$wrapper.find('#search_date');
        $dateRangePicker.daterangepicker({
            showDropdowns: true,
            //autoUpdateInput: false,
            drops: "down",
            autoApply: true,
            locale: {
                format: "YYYY-MM-DD",
                separator: " ~ ",
                applyLabel: l('DateRangePicker:ApplyLabel'),
                cancelLabel: l('DateRangePicker:CancelLabel'),
                fromLabel: l('DateRangePicker:FromLabel'),
                toLabel: l('DateRangePicker:ToLabel'),
                weekLabel: 'W',
                customRangeLabel: l('DateRangePicker:RangeLabel'),
                daysOfWeek: moment.localeData().weekdaysShort(),
                monthNames: moment.localeData().months(),
            },
            startDate: moment().add(-1, 'days'),
            endDate: moment(),
            minDate: moment().add(-10, 'years'),
            maxDate: moment(),
            firstDay: moment.localeData()._week.dow
        });
        _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                order: [[1, 'asc']],
                processing: true,
                serverSide: true,
                searching: false,
                scrollX: true,
                paging: true,
                ajax: abp.libs.datatables.createAjax(_auditLoggingAppService.getList, function () {
                    return initParams();
                }
                ),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('View'),
                                    action: function (data) {
                                        _detailModal.open({
                                            id: data.record.id,
                                        });
                                    },
                                },
                            ]
                        }
                    },
                    {
                        title: l('ApplicationName'),
                        data: 'applicationName'
                    },
                    {
                        title: l('ClientIpAddress'),
                        data: 'clientIpAddress',
                    },
                    {
                        title: l('HttpMethod'),
                        data: 'httpMethod',
                    }
                    ,
                    {
                        title: l('Url'),
                        data: 'url',
                    }
                    ,
                    {
                        title: l('ExecutionTime'),
                        data: 'executionTime',
                    }
                    ,
                    {
                        title: l('ExecutionDuration'),
                        data: 'executionDuration',
                    },
                    {
                        title: l('HttpStatusCode'),
                        data: 'httpStatusCode',
                    }
                ]
            })
        );

        $('#search_httpMethod').select2({
            theme: 'bootstrap-5',
            language: "zh-CN",
            allowClear: true,
            minimumResultsForSearch: -1,
            placeholder: l('ChoosePlaceholder', l('HttpMethod'))
        })
        _$searchBth.click(function () {
            _dataTable.ajax.reload();
        });
        _$resetBth.click(function () {
            $('#search_httpMethod').val(null).trigger('change');
            $('#search_url').val('');
            $('#search_httpStatusCode').val('');
            $dateRangePicker.data('daterangepicker').setStartDate(moment().add(-1, 'days'));
            $dateRangePicker.data('daterangepicker').setEndDate(moment());
            _dataTable.ajax.reload();
        });
    });

    function initParams() {
        var date = $('#search_date').val();
        return {
            httpMethod: $('#search_httpMethod').val(),
            url: $('#search_url').val(),
            httpStatusCode: $('#search_httpStatusCode').val(),
            startDate: new Date(date.split('~')[0].trim() + ' 00:00:00'),
            endDate: new Date(date.split('~')[1].trim() + ' 23:59:59')
        };
    }
})(jQuery);