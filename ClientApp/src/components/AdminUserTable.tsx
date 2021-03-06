import React, { useState } from 'react';
import Table from '@material-ui/core/Table';
import {
  TableContainer,
  Paper,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button,
} from '@material-ui/core';
import ButtonGroup from '@material-ui/core/ButtonGroup';
import IStorageUser from '../interfaces/IStorageUser';
import EditUserModal from './modals/EditUserModal';
import { useDispatch } from 'react-redux';
import { deleteUser } from '../store/actionCreators/userCreator';

interface Prop {
  users: IStorageUser[];
}

export default function AdminUserTable({ users }: Prop) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const dispatch = useDispatch();
  const [clickedUser, setClickedUser] = useState<IStorageUser>({
    username: '',
    id: '',
    role: '',
  });

  const openModal = () => {
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  return (
    <TableContainer component={Paper}>
      <Table aria-label='simple table'>
        <TableHead>
          <TableRow>
            <TableCell align='center'>ID</TableCell>
            <TableCell align='left'>Username</TableCell>
            <TableCell align='left'>Role</TableCell>
            <TableCell align='center'>Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {users.map((user: IStorageUser, key: number) => (
            <TableRow key={key}>
              <TableCell align='center'>{user.id}</TableCell>
              <TableCell align='left'>{user.username}</TableCell>
              <TableCell align='left'>{user.role}</TableCell>
              <TableCell align='center'>
                <ButtonGroup
                  color='primary'
                  aria-label='outlined primary button group'
                >
                  <Button
                    onClick={() => {
                      openModal();
                      setClickedUser(user);
                    }}
                  >
                    Edit
                  </Button>
                  <Button
                    color='secondary'
                    onClick={() => dispatch(deleteUser(user.id!))}
                  >
                    Delete
                  </Button>
                </ButtonGroup>
              </TableCell>
            </TableRow>
          ))}
          <EditUserModal
            closeModal={closeModal}
            isModalOpen={isModalOpen}
            user={clickedUser}
          />
        </TableBody>
      </Table>
    </TableContainer>
  );
}
