


function carregarCampoData(idCampoData, dataMinima, dataMaxima, textoToolTipBotaoCalendario) {
    if (idCampoData.search('#') === -1) idCampoData = '#' + idCampoData;

    if (textoToolTipBotaoCalendario === undefined || textoToolTipBotaoCalendario == null || textoToolTipBotaoCalendario === '') {
        textoToolTipBotaoCalendario = 'Selecione uma data';
    }

    if ((dataMinima === undefined || dataMinima == null) && (dataMaxima === undefined || dataMaxima == null)) {
        
    }
    else if (dataMaxima === true) {
            dataMaxima = new Date();
        }
    else {
        if (dataMinima === undefined) {
            dataMinima = null;
        }

        if (dataMaxima === undefined) {
            dataMaxima = null;
        }
    }

    //$(idCampoData).datepicker({
    //    showOn: "button",
    //    //buttonImage: "Scripts/jquery-ui/images/calendar.gif",
    //    buttonImageOnly: true,
    //    buttonText: textoToolTipBotaoCalendario,
    //    dateFormat: "dd/mm/yy",
    //    maxDate: dataMaxima,
    //    minDate: dataMinima,
    //    changeMonth: true,
    //    changeYear: true
    //});

    $(idCampoData).datepicker({
        showOn: 'button',
        buttonImage: '/assets/calendario-vermelho-branco.png',
        buttonImageOnly: true,
        /*buttonText: textoToolTipBotaoCalendario,*/
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        maxDate: dataMaxima,
        minDate: dataMinima,
        nextText: 'Próximo',
        prevText: 'Anterior'
    });

    $(idCampoData).datepicker("option", $.datepicker.regional["pt-BR"]);
}