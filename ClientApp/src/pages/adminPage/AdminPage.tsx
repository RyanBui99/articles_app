import { Paper, Box, Typography, Container, Button } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import AdminUserTable from '../../components/AdminUserTable';
import CreateUserModal from '../../components/modals/CreateUserModal';
import NavbarComponent from '../../components/NavbarComponent';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getUsers } from '../../store/actionCreators/userCreator';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
  container: {
    marginTop: theme.spacing(4),
  },
  paper: {
    padding: theme.spacing(3),
    color: theme.palette.text.secondary,
  },
}));

export default function AdminPage() {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const dispatch = useDispatch();
  const { users } = useTypedSelector((state) => state.users);
  const classes = useStyles();

  const openModal = () => {
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  useEffect(() => {
    dispatch(getUsers());
  }, [dispatch]);

  return (
    <>
      <NavbarComponent />
      <div className={classes.root}>
        <Container className={classes.container} maxWidth='lg'>
          <Paper className={classes.paper}>
            <Box display='flex'>
              <Box flexGrow={2}>
                <Typography
                  component='h2'
                  variant='h6'
                  color='primary'
                  gutterBottom
                >
                  USERS
                </Typography>
              </Box>
              <Box>
                <Button
                  variant='contained'
                  color='primary'
                  onClick={openModal}
                >
                  CREATE
                </Button>
                <CreateUserModal closeModal={closeModal} isModalOpen={isModalOpen} />
              </Box>
            </Box>
            <AdminUserTable users={users} />
          </Paper>
        </Container>
      </div>
    </>
  );
}
