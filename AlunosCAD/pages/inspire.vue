<template>
  <v-card>
    <v-toolbar color="white" flat>

      <v-toolbar-title class="grey--text text--darken-4">
      Cadastro Aluno
      </v-toolbar-title>

      <v-spacer></v-spacer>
    </v-toolbar>

    <v-container fluid>
      <v-form ref="form" v-model="valid" lazy-validation>
        <v-text-field
          v-model="aluno.nome"
          :min="5"
          :rules="nomeRules"
          label="Aluno"
          required
        ></v-text-field>

        <v-text-field
          v-model="aluno.curso"
          label="Curso"
        ></v-text-field>

        <v-text-field
          v-model="aluno.disciplina"
          label="Disciplina"
        ></v-text-field>

        <v-btn :disabled="!valid" color="success" class="mr-4" @click="cadastrar">
          Salvar
        </v-btn>
      </v-form>
    </v-container>

    <v-footer class="mt-12"></v-footer>

  <template>
  <v-simple-table dense>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-left">
            Nome
          </th>
          <th class="text-left">
            Curso
          </th>
          <th class="text-left">
            Disciplina
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in alunos"
          :key="item.name"
        >
          <td>{{ item.nome }}</td>
          <td>{{ item.curso }}</td>
          <td>{{ item.disciplina }}</td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>
  </v-card>
</template>

<script>
  
export default {
  data: () => ({
    valid: true,
    aluno: {
      nome: "",
      curso: "",
      disciplina: "",

    },
    nomeRules: [
      (v) => !!v || "Nome é obrigatório",
      (v) =>
        (v && v.length > 5) || "Nome precisa de ter pelo menos 5 caracteres",
    ],

    alunos: [],
  }),

  // mounted(){
  //   this.getAluno();
  // },

  async asyncData({ $axios }) {
    const res = await $axios.$get('https://localhost:7023/api/Values' )
  // console.log(res)
  return {alunos: res}
},

  methods: {

    async cadastrar() {
      try {
        const responsePOST = await this.$axios({
          method: "POST",
          url: "https://localhost:7023/api/Values",
          data: this.aluno
        });
        this.$nuxt.refresh();
        this.$refs.form.reset();

      } catch {}

      console.log(this.alunos)
    },
  },
};
</script>

<style></style>