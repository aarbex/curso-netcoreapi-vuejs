import Vue from 'vue'
import Router from 'vue-router'
import Alunos from './components/Aluno/Alunos.vue'
import AlunoDetalhe from './components/Aluno/AlunoDetalhe.vue'
import Professores from './components/Professor/Professores'
import Sobre from './components/Sobre/Sobre'

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/professores',
            nome: 'Professores',
            component: Professores
        },
        {
            path: '/alunos',
            nome: 'Todos_Alunos',
            component: Alunos
        },
        {
            path: '/alunos/:prof_id',
            nome: 'Alunos_Professor',
            component: Alunos
        },
        {
            path: '/aluno/:id',
            nome: 'Aluno_Detalhe',
            component: AlunoDetalhe
        },
        {
            path: '/sobre',
            nome: 'Sobre',
            component: Sobre
        }
    ]
})