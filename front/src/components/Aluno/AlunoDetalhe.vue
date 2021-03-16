<template>
  <div v-if="!loading">
    <Titulo
      :texto="`Aluno: ${aluno.nome} ${aluno.sobrenome}`"
      :btnVoltar="!view"
    >
      <button v-show="view" class="btn btnEditar" @click="editar()">
        Editar
      </button>
    </Titulo>

    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matricula</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome</td>
          <td>
            <label v-if="view">{{ aluno.nome }}</label>
            <input v-else type="text" v-model="aluno.nome" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome</td>
          <td>
            <label v-if="view">{{ aluno.sobrenome }}</label>
            <input v-else type="text" v-model="aluno.sobrenome" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nasc.</td>
          <td>
            <label v-if="view">{{ aluno.dt_nasc }}</label>
            <input v-else type="text" v-model="aluno.dt_nasc" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor</td>
          <td>
            <label v-if="view">{{ aluno.professor.nome }}</label>
            <select v-else v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor.id"
                >{{ professor.nome }}</option
              >
            </select>
          </td>
        </tr>
      </tbody>
    </table>
    <div style="margin-top: 10px">
      <div v-if="!view">
        <button class="btn btnSalvar" @click="salvar()">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
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
                professores: [],
                aluno: {},
                id: this.$route.params.id,
                view: true,
                loading: true
            }
        },
        created(){
            this.carregarProfessor();
        },
        methods: {
            carregarProfessor(){
                this.$http
                .get("http://localhost:5000/api/professor")
                .then((res) => res.json())
                .then(professores => {
                    this.professores = professores;
                    this.carregarAluno();
            });
                
            },
            carregarAluno(){
                 this.$http
                .get(`http://localhost:5000/api/aluno/${this.id}`)
                .then(res => res.json())
                .then(aluno => {
                    this.aluno = aluno;
                    this.loading = false;
                    });
            },
            editar(){
                this.view = !this.view;
            },
            cancelar(){
                 this.view = !this.view;
            },
            salvar(){
                let _alunoEditar ={
                    id: this.aluno.id,
                    nome: this.aluno.nome,
                    sobrenome: this.aluno.sobrenome,
                    dt_nasc: this.aluno.dt_nasc,
                    professorid: this.aluno.professor.id
                }
                this.$http
                .put(`http://localhost:5000/api/aluno/${_alunoEditar.id}`, _alunoEditar)
                .then(res => res.json())
                .then(aluno => this.aluno = aluno)
                .then(() => this.view = true);

                this.view = !this.view;


            }


        }
    }
</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}
.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}
.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}
.colPequeno {
  width: 20%;
}
input,
select {
  margin: 0;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  background-color: rgb(245, 245, 245);
  width: 95%;
}
select {
  height: 38px;
  width: 100%;
}
</style>
