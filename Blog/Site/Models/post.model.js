'use strict';

/**
 * @ngdoc service
 * @name blogApp.postModel
 * @description
 * # postModel
 * Factory in the blogApp.
 */
angular.module('surApp')
  .factory('postModel', function ( session) {

    /**
     * Constructor, with class name
     */
    function Post(titulo, conteudo) {
      // Parent constructor
      itemDePlanoModel.call(this);
      var that = this;

      // Public properties, assigned to the instance ('this')
      this.titulo=titulo;
      this.conteudo = conteudo;
      this.dataPostagem = {};
      that.dataExclusao = {};

      Object.defineProperty(that.valorSolicitado, 'valorBase', {
          enumerable: false,
          get: function(){
            return that.valorSolicitado._valorBase;
          },
          set: function(newValue){
            that.valorSolicitado._valorBase = newValue;
            atualizarValorSolicitado();
          }
      });


    Despesa.build = function (data) {
      data = data || {};
      var despesa = new Despesa(data.nome);
      angular.extend(despesa, data);
      return despesa;
    };

    Despesa.prototype = Object.create(itemDePlanoModel.prototype);

    Despesa.prototype.formasDePagamentoPermitidas = function () {
      var usaDoTipo = this.tipo && this.tipo.formasPagto && this.tipo.formasPagto.length;
      return usaDoTipo ? this.tipo.formasPagto : Object.keys(resources.formaDePagto);
    };

    Despesa.prototype.usaCartaoCorporativo = function () {
      return this.formaPagto === 'CartaoCorporativo';
    };

    Despesa.prototype.permiteExcluir = function (plano) {
      return itemDePlanoModel.permiteExcluir(plano, 'Despesa', session, this.tipoDeItem, this.status, this);
    };

    Despesa.prototype.permiteEditar = function (plano) {
      return itemDePlanoModel.permiteEditar(plano, this, session, 'Despesa');
    };

    Despesa.prototype.bloquearEdicao = function () {
        return this.servico || this.conciliado;
    };

    Despesa.apiResponseTransformer = function (response) {
      if (angular.isArray(response.data)) {
        return response.data
          .map(Despesa.build);
      }
      return Despesa.build(response.data);
    };

    return Despesa;
  });
