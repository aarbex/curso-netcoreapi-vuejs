<template>
  <div>
    <Titulo texto="Professores" btnVoltar="true"/>
    <table>
      <thead>
        <th>Cód.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="professor in professores" :key="professor.id">
          <td class="colPequeno">{{ professor.id }}</td>
          <router-link 
          :to="`/alunos/${professor.id}`" 
          tag="td" 
          style="cursor: pointer">
            {{ professor.nome }}
          </router-link>
          <td class="colPequeno">
            {{professor.qtdeAlunos}}
            <!-- <button class="btn btn_danger" @click="removerAluno(professores)">Remover</button> -->
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center"><h5>Nenhum professor encontrado!</h5></td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../Titulo/Titulo";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      alunos: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:5000/api/aluno")
      .then((res) => res.json())
      .then(alunos => {
        this.alunos = alunos;
        this.carregarProfessores();
      })
  },
  props: {},
  methods: {
    pegarQtdeAlunos(){
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdeAlunos: this.alunos.filter(aluno => aluno.professor.id == professor.id).length
        }
        this.professores[index] = professor;
      });    
    },
    carregarProfessores(){
          this.$http
          .get("http://localhost:5000/api/professor")
          .then((res) => res.json())
          .then(professores => {
            this.professores = professores;
            this.pegarQtdeAlunos()
          });
        }
  }
};
</script>

<style scoped>
input {
  width: calc(100% - 190px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btn_input {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
  display: inline;
}

.btn_input:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
.colPequeno{
  text-align: center; 
  width: 15%;
}
</style>
