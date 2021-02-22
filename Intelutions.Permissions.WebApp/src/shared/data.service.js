import * as axios from 'axios';

import { format } from 'date-fns';
import { inputDateFormat } from './constants';

import { API } from './config';

const getPermissions = async function() {
  try {
    const response = await axios.get(`${API}/permission`);

    let data = parseList(response);

    const permissions = data.map(p => {
      p.permissionDate = format(new Date(p.permissionDate), inputDateFormat);
      p.fullname = `${p.employeeFirstname} ${p.employeeLastname}`;
      return p;
    });
    return permissions;
  } catch (error) {
    console.error(error);
    return [];
  }
};

const getPermissionTypes = async function() {
    try {
      const response = await axios.get(`${API}/permissiontype`);
  
      let data = parseList(response);
  
      const permissionTypes = data.map(pt => {
        var newPt = {};
        newPt["value"] = pt.id;
        newPt["text"] = pt.description;
        return newPt;
      });
      return permissionTypes;
    } catch (error) {
      console.error(error);
      return [];
    }
  };

const getPermission = async function(id) {
  try {
    const response = await axios.get(`${API}/permission/${id}`);
    let permission = parseItem(response, 200);
    permission.permissionDate = format(new Date(permission.permissionDate), inputDateFormat);
    permission.fullname = `${permission.employeeFirstname} ${permission.employeeLastname}`;
    return permission;
  } catch (error) {
    console.error(error);
    return null;
  }
};

const updatePermission = async function(permission) {
  try {
    const response = await axios.put(`${API}/permission/${permission.id}`, permission);
    const updatedPermission = parseItem(response, 200);
    return updatedPermission;
  } catch (error) {
    console.error(error);
    return null;
  }
};

const addPermission = async function(permission) {
  try {
    delete permission.id;
    const response = await axios.post(`${API}/permission`, permission);
    const addedPermission = parseItem(response, 202);
    return addedPermission;
  } catch (error) {
    console.error(error);
    if(error.response) {
        var message = '';
        if (error.response.status === 400) {
            for (var i in error.response.data.errors) {
              message += `${error.response.data.errors[i].join()} `;
            }
        }
        if (error.response.status === 404) {
            message = error.response.message;
        }
        
        return {
            message: message
        };
    }
    return null;
  }
};

const deletePermission = async function(permission) {
  try {
    const response = await axios.delete(`${API}/permission/${permission.id}`);
    parseItem(response, 200);
    return permission.id;
  } catch (error) {
    console.error(error);
    return null;
  }
};

const parseList = response => {
  if (response.status !== 200) throw Error(response.message);
  if (!response.data.data) return [];
  let list = response.data.data;
  if (typeof list !== 'object') {
    list = [];
  }
  return list;
};

export const parseItem = (response, code) => {
  if (response.status !== code) throw Error(response.message);
  let item = response.data;
  if (typeof item !== 'object') {
    item = undefined;
  }
  return item;
};

export const dataService = {
  getPermissions,
  getPermissionTypes,
  getPermission,
  updatePermission,
  addPermission,
  deletePermission,
};
