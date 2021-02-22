<template>
  <div class="content-container">
    <div class="columns">
      <div class="column is-8">
        <div class="section content-title-group">
          <h2 class="title">Permisos</h2>
          <button class="button refresh-button" @click="loadPermissions()">
            <i class="fas fa-sync"></i>
          </button>
          <router-link tag="button" class="button add-button" :to="{ name: 'permission-detail', params: { id: 0 } }" >
            <i class="fas fa-plus"></i>
          </router-link>
          <div>
              <br/>
          </div>
          <div>
              <b-card-group v-for="permission in permissions" :key="permission.id" style="padding: 1rem;" deck>
                <b-card title="" header-tag="header" footer-tag="footer">
                  <template #header>
                    <h5 class="mb-0"><b>{{ permission.id }}:</b> {{ permission.employeeFirstname }} {{ permission.employeeLastname }}</h5>
                  </template>
                  <b-card-text><b>Tipo de permiso:</b> {{ permission.permissionTypeDescription }}</b-card-text>
                  <b-button-group>
                    <b-button href="#" variant="danger" @click="askToDelete(permission)">
                      <i class="fas fa-trash"></i>
                      <span> Eliminar</span>
                    </b-button>
                    <b-button tag="button" variant="success" :to="{ name: 'permission-detail', params: { id: permission.id } }" >
                      <i class="fas fa-check"></i>
                      <span> Editar</span>
                    </b-button>
                  </b-button-group>
                  <template #footer>
                    <em><b>Fecha del permiso:</b> {{ permission.permissionDate }}</em>
                  </template>
                </b-card>
              </b-card-group>
              <div>
                <br/>
              </div>
          </div>
        </div>
        <div class="notification is-info" v-show="message">{{ message }}</div>
      </div>
    </div>

    <b-modal ref="yesno-modal" hide-footer title="Confirmar">
      <div class="d-block text-center">
          <h3>{{ modalMessage }}</h3>
        </div>
        <b-button class="mt-3" variant="outline-danger" block @click="closeModal">No</b-button>
        <b-button class="mt-2" variant="outline-warning" block @click="deletePermission">Si</b-button>
    </b-modal>
  </div>
</template>

<script>

import { dataService } from '../shared';

export default {
  name: 'Permissions',
  data() {
    return {
      permissions: [],
      permissionToDelete: null,
      message: '',
      modalMessage: ''
    };
  },
  components: {
  },
  async created() {
    await this.loadPermissions();
  },
  methods: {
    askToDelete(permission) {
      this.permissionToDelete = permission;
      const name = this.permissionToDelete && this.permissionToDelete.fullname ? this.permissionToDelete.fullname : '';
      this.modalMessage = `¿ Quieres eliminar el permiso de ${name} ?`;
      this.$refs['yesno-modal'].show();
    },
    closeModal() {
      this.$refs['yesno-modal'].hide();
    },
    async deletePermission() {
      this.closeModal();
      if (this.permissionToDelete) {
        await dataService.deletePermission(this.permissionToDelete);
        await this.loadPermissions();
      }
    },
    async loadPermissions() {
      this.permissions = [];
      this.message = 'Obteniendo los permisos, por favor se paciente';
      this.permissions = await dataService.getPermissions();
      this.message = '';
      this.modalMessage = '';
    },
  },
  computed: {
  },
};
</script>
