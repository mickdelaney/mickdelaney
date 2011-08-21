SelectItem = Backbone.Model.extend({
    defaults: {
        Id: "",
		Selected: "",
		Value: ""
	}
});
SelectItems = Backbone.Collection.extend({
    model: SelectItem
});        

Message = Backbone.Model.extend({
	defaults: {
        Id: "",
		Name: "",
		Description: "",
	    MessageTypeId: "1",
	    MessageTypeName: ""
	},
    toggleStatus: function() {
        
    },
	save: function () {
		console.log(name);
	}
});

Messages = Backbone.Collection.extend({
	model: Message,
	url : "/messages"
});

MessageItemView = Backbone.View.extend({
    tagName: "li",
        
    initialize: function (options) {
        _.bindAll(this, "render", "toggleComplete", "setStatus", "clear", "updateModel");
        
        this.template = $("#item-template");
        this._messageTypes = options.messageTypes;
        
        this.model.bind("change:status", this.setStatus);
        this.model.bind("change:Name", this.render);
        this.model.bind("change:MessageTypeName", this.render);
    },
    events: {
        "click :checkbox": "toggleComplete",
        "click span.todo-destroy": "clear",
        "click button.save": "updateModel",
        "dblclick div.todo": "toggleEdit"
    },
    render: function () {
        var model = {
            Item: this.model.toJSON(),
            Idx: this.model.cid,
            MessageTypes: this._messageTypes
        };

        var content = this.template.tmpl(model);
        $(this.el).html(content);
        return this;
    },
    toggleComplete: function () {
        this.model.toggleStatus();
    },
    clear: function (evt) {
        tasks.remove(this.model);
    },
    setStatus: function () {
        //trigger the status change
        this.$(".todo").toggleClass("done");
    },
    toggleEdit: function () {
        $(this.el).toggleClass("editing");
        this.$("input").focus();
    },
    updateModel: function () {
        $(this.el).toggleClass("editing");
        var messageTypeId = this.$(".message-type-input").val();
        var messageTypeName = this.$(".message-type-input :selected").text();
        var message = this.$(".todo-input").val();
        this.model.set({ Name: message, MessageTypeName: messageTypeName, MessageTypeId: messageTypeId });
    }
});

MessageListView = Backbone.View.extend({
    el: "#messages-list",

    initialize: function (options) {
        _.bindAll(this, "render");

        this._messageTypes = options.messageTypes;
        this.collection.bind("fetch", this.render);
    },
    render: function () {
        $(this.el).empty();
        var els = [];
        var self = this; //this!!!
        this.collection.each(function (model) {
            var view = new MessageItemView({ model: model, messageTypes: self._messageTypes });
            els.push(view.render().el);
        });
        //push that array into this View's "el"
        $(this.el).append(els);
        return this;
    }
});