<template>
  <div>
    
    <titulo :texto=" prof_id != undefined ? 'Alunos do professor ' + professor.nome : 'Todos os Alunos'" btnVoltar="true"/>
    
    <div v-show="prof_id">
      <input 
        type="text" 
        placeholder="Nome do Aluno"
        v-model="nome"
        @keyup.enter="addAluno()">
        <button class="btn btn_input" @click="addAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Matr.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="aluno in alunos" :key="aluno.id">
          <td class="colPequeno">{{aluno.id}}</td>
          <router-link 
          :to="`/aluno/${aluno.id}`"
          tag="td"
          style="cursor: pointer">
            {{aluno.nome}} {{aluno.sobrenome}}
          </router-link>
          <td class="colPequeno"> 
            <button class="btn btn_danger" @click="removerAluno(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center"><h5>Nenhum aluno encontrado!</h5></td>
        </tr>
      </tfoot>
    </table>

  </div>
</template>

<script>
import Titulo from '../Titulo/Titulo'
export default {
  components: {
    Titulo
  },
  data(){
    return {
      titulo: 'Aluno',
      prof_id: this.$route.params.prof_id,
      nome: '',
      professor: {},
      alunos: []
    }
  },
  created(){
    if(this.prof_id){
      this.carregarProfessor();
      this.$http
      .get(`http://localhost:5000/api/aluno/ByProfessor/${this.prof_id}`)
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    } else {
      this.$http
      .get('http://localhost:5000/api/aluno')
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    }   
  },
  props: {
  },
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: '',
        dt_nasc: '',
        professorid: this.professor.id
      };

    this.$http
      .post('http://localhost:5000/api/aluno', _aluno)
      .then(res => res.json())
      this.nome = '';
      location.reload()
    },

    carregarProfessor(){
       this.$http
        .get(`http://localhost:5000/api/professor/${this.prof_id}`)
        .then(res => res.json())
        .then(professor => this.professor = professor)
    },

    removerAluno(aluno){
      this.$http
            .delete(`http://localhost:5000/api/aluno/${aluno.id}`)
            .then(() => {
              let indice = this.alunos.indexOf(aluno);
              this.alunos.splice(indice, 1);
            })

      
      //this.alunos.splice(indice, 1);
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  input{
    width: calc(100% - 190px);
    border: 0;
    padding: 20px;
    font-size: 1.3em;
    color: #687f7f;
    display: inline;
  }
  .btn_input{
    width: 150px;
    border: 0px;
    padding: 20px;
    font-size: 1.3em;
    background-color: rgb(116, 115, 115);
    display: inline;
  }

  .btn_input:hover{
    padding: 20px;
    margin: 0px;
    border: 0px;
  }
</style>
