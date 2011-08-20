Message = Backbone.Model.extend({
	defaults: {
        Id: "",
		Name: "",
		Description: ""
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
	tagName : "li",
	initialize : function(){
		this.template = $("#item-template");
		//rescope "this" so it's available to the methods requiring it
		_.bindAll(this,"render","toggleComplete","setStatus","clear","updateModel");
		//bind the change event to the status toggle
		this.model.bind("change:status",this.setStatus);
		this.model.bind("change:name",this.render);
	}, 
	events : {
		"click :checkbox" : "toggleComplete",
		"click span.todo-destroy"   : "clear",
		"dblclick div.todo-content" : "toggleEdit",
		"blur .todo-input" : "updateModel"
	},
	render : function(){
		var content = this.template.tmpl(this.model.toJSON());
		$(this.el).html(content);
		return this;
	},
	toggleComplete : function(){
		this.model.toggleStatus();
	},
	clear : function(evt){
		tasks.remove(this.model);
	},
	setStatus : function(){
		//trigger the status change
		this.$(".todo").toggleClass("done");
	},
	toggleEdit : function(){
	  $(this.el).toggleClass("editing");
      this.$("input").focus();
	},
	updateModel : function(){
		$(this.el).toggleClass("editing");
		this.model.set({name :  this.$(".todo-input").val()});
	},
});

MessageListView = Backbone.View.extend({
    el: "#messages-list",
    initialize: function () {
        _.bindAll(this, "render");
        this.collection.bind("fetch", this.render);
    },
    render: function () {
        $(this.el).empty();
        var els = [];
        
        this.collection.each(function (model) {
            var view = new MessageItemView({ model: model });
            els.push(view.render().el);
        });
        //push that array into this View's "el"
        $(this.el).append(els);
        return this;
    }
});

$(function () { 

    var messages = new Messages;
    listView = new MessageListView({collection: messages});

    messages.fetch({
        success: function (collection, response) {
            collection.each(function (message) {
                console.log(message.get("Name"));
            });    

            listView.render();
        }
    });

    
    

});