(function () {
    window.QuillFunctions = {
        createQuill: function (quillElement) {


            //var toolbarOptions = {
            //    container: [
            //        ['bold', 'italic', 'underline', 'strike'],
            //        ['blockquote', 'code-block'],
            //        [{ 'header': 1 }, { 'header': 2 }],
            //        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
            //        [{ 'script': 'sub' }, { 'script': 'super' }],
            //        [{ 'indent': '-1' }, { 'indent': '+1' }],
            //        [{ 'direction': 'rtl' }],
            //        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
            //        [{ 'color': [] }, { 'background': [] }],
            //        [{ 'font': [] }],
            //        [{ 'align': [] }],
            //        ['clean'],
            //        ['emoji'],
            //        ['link']
            //    ],
            //    handlers: {
            //        'emoji': function () { }
            //    }
            //}

            var toolbarOptions = {
                container: '#toolbar',
                handlers: {
                    'emoji': function () { }
                }
            }

            var options = {
                modules: {
                    "toolbar": toolbarOptions,
                    "emoji-toolbar": true,
                    "emoji-shortname": true,
                    "emoji-textarea": true
                },
                placeholder: 'Compose an epic...',
                readOnly: false,
                theme: 'snow'
            };

            //var options = {
            //    modules: {
            //        toolbar: '#toolbar',
            //    },
            //    placeholder: 'Compose an epic...',
            //    readOnly: false,
            //    theme: 'snow'
            //};


            // set quill at the object we can call
            // methods on later
            new Quill(quillElement, options);
        },
        getQuillContent: function (quillControl) {
            return JSON.stringify(quillControl.__quill.getContents());
        },
        getQuillText: function (quillControl) {
            return quillControl.__quill.getText();
        },
        getQuillHTML: function (quillControl) {
            var elements = document.getElementsByClassName("ql-editor");
            var requiredElement = elements[0];           
            return requiredElement.innerHTML;
            //return quillControl.__quill.root.innerHTML;
        },
        ClearQuillContent: function (quillControl) {
            //var elements = document.getElementById(quillControl);
            //elements.__quill.root.innerHTML = "";
            var elements = document.getElementsByClassName("ql-editor");
            elements[0].innerHTML = "";
            return;
        },
        loadQuillContent: function (quillControl, quillContent) {
            content = JSON.parse(quillContent);
            return quillControl.__quill.setContents(content, 'api');
        },
        disableQuillEditor: function (quillControl) {
            document.getElementById(quillControl).editor.enable(false);
        },
        enableQuillEditor: function (quillControl) {
            var elements = document.getElementById(quillControl);
            elements.__quill.enable(true);
        }
    };
})();