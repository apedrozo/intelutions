<template>
  <div>
    <div class="section content-title-group">
      <h2 class="title">{{ title }}</h2>

      <div class="card">
        <header class="card-header">
          <p class="card-header-title">{{ permission.fullname }}</p>
        </header>
        <div class="card-content">
          <div class="content" style="padding: 1rem;">
            <b-form @submit.stop.prevent="savePermission" @reset="cancelPermission">
              <b-form-group id="input-group-1" label="ID:" label-for="id">
                <b-form-input id="id" v-model="permission.id" readonly></b-form-input>
              </b-form-group>

              <b-form-group id="input-group-2" label="Nombre del empleado:" label-for="firstName">
                <b-form-input id="firstName" v-model="permission.employeeFirstname" 
                  placeholder="Ingresa el nombre del empleado" 
                  :state="validateState('employeeFirstname')" 
                  aria-describedby="input-2-live-feedback"></b-form-input>

                <b-form-invalid-feedback id="input-2-live-feedback">
                  El campo es requerido y solo hasta 200 caracteres.
                </b-form-invalid-feedback>
              </b-form-group>
              
              <b-form-group id="input-group-3" label="Apellidos del empleado:" label-for="lastName">
                <b-form-input id="lastName" v-model="permission.employeeLastname" 
                  placeholder="Ingresa los apellidos del empleado" 
                  :state="validateState('employeeLastname')" 
                  aria-describedby="input-3-live-feedback" ></b-form-input>

                <b-form-invalid-feedback id="input-3-live-feedback">
                  El campo es requerido y solo hasta 200 caracteres.
                </b-form-invalid-feedback>
              </b-form-group>

              <b-form-group id="input-group-4" label="Tipo de permiso:" label-for="permissionType">
                    <b-form-select id="permissionType" v-model="permission.permissionTypeId" 
                      :options="permissionTypes" 
                      :state="validateState('permissionTypeId')" 
                      aria-describedby="input-4-live-feedback"></b-form-select>

                      <b-form-invalid-feedback id="input-4-live-feedback">
                        El campo es requerido.
                      </b-form-invalid-feedback>
                </b-form-group>

              <b-form-group id="input-group-5" label="Tipo de permiso:" label-for="permissionDate">
                    <b-form-input id="permissionDate" type="date" placeholder="yyyy-mm-dd" 
                      v-model="permission.permissionDate" 
                      :state="validateState('permissionDate')" 
                      aria-describedby="input-5-live-feedback"></b-form-input>

                    <b-form-invalid-feedback id="input-5-live-feedback">
                        El campo es requerido.
                      </b-form-invalid-feedback>
                </b-form-group>
              
              <b-button-group>
                <b-button type="submit" variant="success"><i class="fas fa-save"></i><span> Guardar</span></b-button>
                <b-button type="reset" variant="danger"><i class="fas fa-undo"></i><span> Cancelar</span></b-button>
              </b-button-group>
            </b-form>
          </div>
        </div>
      </div>
    </div>
    <div v-show="errors.length" class="notification is-info">
        <ul>
          <li v-for="error in errors" :key="error">{{ error }}</li>
        </ul>
    </div>
  </div>
</template>

<script>
import { validationMixin } from "vuelidate";
import { required, maxLength } from "vuelidate/lib/validators";

import { dataService } from '../shared';
import { format } from 'date-fns';
import { inputDateFormat } from '../shared/constants';

export default {
  mixins: [ validationMixin ],
  name: 'PermisionDetail',
  props: {
    id: {
      type: Number,
      default: 0,
    },
  },
  data() {
    return {
      permission: {},
      permissionTypes: [],
      message: '',
      errors: []
    };
  },
  async created() {
    this.permissionTypes = await dataService.getPermissionTypes();

    if (this.isAddMode) {
      this.permission = {
        id: undefined,
        employeeFirstname: '',
        employeeLastname: '',
        permissionTypeId: 1,
        permissionDate: format(new Date(), inputDateFormat)
      };
    } else {
      this.permission = await dataService.getPermission(this.id);
    }
  },
  computed: {
    isAddMode() {
      return !this.id;
    },
    title() {
      return `${this.isAddMode ? 'Agregar' : 'Editar'} Permiso`;
    },
  },
  validations: {
    permission: {
      employeeFirstname: {
        required,
        maxLength: maxLength(200)
      },
      employeeLastname: {
        required,
        maxLength: maxLength(200)
      },
      permissionTypeId: {
        required
      },
      permissionDate: {
        required
      }
    }
  },
  methods: {
    validateState(name) {
      const { $dirty, $error } = this.$v.permission[name];
      return $dirty ? !$error : null;
    },
    cancelPermission() {
      this.$router.push({ name: 'permissions' });
    },
    async savePermission() {
      var dateString = JSON.stringify(new Date(this.permission.permissionDate));
      if (dateString[0] === '"' || dateString[0] === "'")
      {
        dateString = dateString.substr(1, dateString.length - 2);
        if (dateString[dateString.length -1] === "Z") {
          dateString = dateString.substr(0, 10);
        }
      }
      this.permission.permissionDate = dateString;

      this.$v.permission.$touch();
      if (this.$v.permission.$anyError) {
        return;
      }

      if (this.permission.id)
      {
        await dataService.updatePermission(this.permission);
        this.errors = [];
        this.$router.push({ name: 'permissions' });
      } else {
        var response =  await dataService.addPermission(this.permission);
        if (response.message) {
          this.errors.push(response.message);
        } else {
          this.$router.push({ name: 'permissions' });
        }
      }
    }
  },
};
</script>
